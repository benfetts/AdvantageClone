Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanStaffClientAssignmentProduct
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Selected() As Boolean
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Selected = False
            Me.ClientCode = Nothing
            Me.ClientName = String.Empty
            Me.DivisionCode = Nothing
            Me.DivisionName = String.Empty
            Me.ProductCode = Nothing
            Me.ProductName = String.Empty

        End Sub
        Public Sub New(Product As AdvantageFramework.Database.Views.ProductView)

            Me.Selected = False
            Me.ClientCode = Product.ClientCode
            Me.ClientName = Product.ClientName
            Me.DivisionCode = Product.DivisionCode
            Me.DivisionName = Product.DivisionName
            Me.ProductCode = Product.ProductCode
            Me.ProductName = Product.ProductDescription

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientName & " - " & Me.DivisionName & " - " & Me.ProductName

        End Function

#End Region

    End Class

End Namespace
