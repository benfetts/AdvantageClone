Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class Product
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
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
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProductName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.DivisionName = String.Empty
            Me.ProductCode = String.Empty
            Me.ProductName = String.Empty

        End Sub
        Public Sub New(Product As AdvantageFramework.Database.Views.ProductView)

            Me.ClientCode = Product.ClientCode
            Me.ClientName = Product.ClientName
            Me.DivisionCode = Product.DivisionCode
            Me.DivisionName = Product.DivisionName
            Me.ProductCode = Product.ProductCode
            Me.ProductName = Product.ProductDescription

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString & "-" & Me.DivisionCode.ToString & "-" & Me.ProductCode.ToString

        End Function

#End Region

    End Class

End Namespace
