Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanRevenueRevisionDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanRevenueID
            RevenueResourcePlanRevenueTypeID
            RevenueResourcePlanRevenueStatusID
            DivisionCode
            Division
            ProductCode
            Product
            JobNumber
            JobComponentNumber
            JobComponent
            Notes
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
        Public Property RevenueResourcePlanRevenueID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Revenue Type")>
        Public Property RevenueResourcePlanRevenueTypeID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Status")>
        Public Property RevenueResourcePlanRevenueStatusID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Division() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Product() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property JobNumber() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property JobComponentNumber() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Job / Component")>
        Public Property JobComponent() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date1Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date1Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date2Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date2Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date3Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date3Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date4Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date4Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date5Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date5Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date6Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date6Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date7Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date7Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date8Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date8Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date9Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date9Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date10Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date10Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date11Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date11Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2", MinValue:=0, UseMinValue:=True)>
        Public Property Date12Revenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property Date12Actual() As Decimal


#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanRevenueID = 0
            Me.RevenueResourcePlanRevenueTypeID = 1
            Me.RevenueResourcePlanRevenueStatusID = 1
            Me.DivisionCode = Nothing
            Me.Division = String.Empty
            Me.ProductCode = Nothing
            Me.Product = String.Empty
            Me.JobNumber = Nothing
            Me.JobComponentNumber = Nothing
            Me.JobComponent = String.Empty
            Me.Notes = String.Empty
            Me.Date1Revenue = 0
            Me.Date1Actual = 0
            Me.Date2Revenue = 0
            Me.Date2Actual = 0
            Me.Date3Revenue = 0
            Me.Date3Actual = 0
            Me.Date4Revenue = 0
            Me.Date4Actual = 0
            Me.Date5Revenue = 0
            Me.Date5Actual = 0
            Me.Date6Revenue = 0
            Me.Date6Actual = 0
            Me.Date7Revenue = 0
            Me.Date7Actual = 0
            Me.Date8Revenue = 0
            Me.Date8Actual = 0
            Me.Date9Revenue = 0
            Me.Date9Actual = 0
            Me.Date10Revenue = 0
            Me.Date10Actual = 0
            Me.Date11Revenue = 0
            Me.Date11Actual = 0
            Me.Date12Revenue = 0
            Me.Date12Actual = 0

        End Sub
        Public Sub New(RevenueResourcePlanRevenueDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail)

            'objects
            Dim RevenueResourcePlanRevenueDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate) = Nothing

            Me.ID = RevenueResourcePlanRevenueDetail.ID
            Me.RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID
            Me.RevenueResourcePlanRevenueTypeID = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID
            Me.RevenueResourcePlanRevenueStatusID = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID
            Me.DivisionCode = RevenueResourcePlanRevenueDetail.DivisionCode
            Me.Division = If(RevenueResourcePlanRevenueDetail.Division IsNot Nothing, RevenueResourcePlanRevenueDetail.Division.Name, String.Empty)
            Me.ProductCode = RevenueResourcePlanRevenueDetail.ProductCode
            Me.Product = If(RevenueResourcePlanRevenueDetail.Product IsNot Nothing, RevenueResourcePlanRevenueDetail.Product.Name, String.Empty)
            Me.JobNumber = RevenueResourcePlanRevenueDetail.JobNumber
            Me.JobComponentNumber = RevenueResourcePlanRevenueDetail.JobComponentNumber
            Me.JobComponent = If(RevenueResourcePlanRevenueDetail.JobComponent IsNot Nothing, RevenueResourcePlanRevenueDetail.JobComponent.ToString(True, True), String.Empty)
            Me.Notes = RevenueResourcePlanRevenueDetail.Notes

            If RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates IsNot Nothing AndAlso RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates.Count > 0 Then

                RevenueResourcePlanRevenueDetailDates = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates.OrderBy(Function(Entity) Entity.Date).ToList

                For Each RevenueResourcePlanRevenueDetailDate In RevenueResourcePlanRevenueDetailDates

                    Select Case RevenueResourcePlanRevenueDetailDates.IndexOf(RevenueResourcePlanRevenueDetailDate)

                        Case 1

                            Me.Date1Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date1Actual = 0

                        Case 2

                            Me.Date2Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date2Actual = 0

                        Case 3

                            Me.Date3Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date3Actual = 0

                        Case 4

                            Me.Date4Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date4Actual = 0

                        Case 5

                            Me.Date5Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date5Actual = 0

                        Case 6

                            Me.Date6Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date6Actual = 0

                        Case 7

                            Me.Date7Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date7Actual = 0

                        Case 8

                            Me.Date8Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date8Actual = 0

                        Case 9

                            Me.Date9Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date9Actual = 0

                        Case 10

                            Me.Date10Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date10Actual = 0

                        Case 11

                            Me.Date11Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
                            Me.Date11Actual = 0

                        Case 12

                            Me.Date12Revenue = RevenueResourcePlanRevenueDetailDate.Revenue
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
