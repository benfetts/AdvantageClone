Namespace DTO

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
            IsInactive
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
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DivisionName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProductCode() As String
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProductName() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsInactive() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property CDP As String
            Get
                CDP = Me.ClientCode & "|" & Me.DivisionCode & "|" & Me.ProductCode
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.DivisionName = String.Empty
            Me.ProductCode = String.Empty
            Me.ProductName = String.Empty
            Me.IsInactive = False

        End Sub
        Public Sub New(Product As AdvantageFramework.Database.Entities.Product)

            Me.ClientCode = Product.ClientCode
            Me.ClientName = Product.Client.Name
            Me.DivisionCode = Product.DivisionCode
            Me.DivisionName = Product.Division.Name
            Me.ProductCode = Product.Code
            Me.ProductName = Product.Name
            Me.IsInactive = (Product.IsActive = 0 OrElse Product.Division.IsActive = 0 OrElse Product.Client.IsActive = 0)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ProductCode.ToString & " - " & Me.ProductName.ToString

        End Function

#End Region

    End Class

End Namespace
