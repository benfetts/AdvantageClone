Namespace DTO.Security.Setup.CDPSecurityGroup

    Public Class CDP
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CDPSecurityGroupID
            OfficeCode
            OfficeName
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CDPSecurityGroupID() As Integer
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office")>
        Public Property OfficeName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client")>
        Public Property ClientName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division")>
        Public Property DivisionName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product")>
        Public Property ProductName() As String
        Public Property IsActive As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.CDPSecurityGroupID = 0
            Me.OfficeCode = String.Empty
            Me.OfficeName = String.Empty
            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.DivisionName = String.Empty
            Me.ProductCode = String.Empty
            Me.ProductName = String.Empty
            Me.IsActive = True

        End Sub
        Public Sub New(Product As AdvantageFramework.Database.Entities.Product)

            Me.CDPSecurityGroupID = Product.CDPSecurityGroupID
            Me.OfficeCode = Product.OfficeCode
            Me.OfficeName = Product.Office.Name
            Me.ClientCode = Product.ClientCode
            Me.ClientName = Product.Client.Name
            Me.DivisionCode = Product.DivisionCode
            Me.DivisionName = Product.Division.Name
            Me.ProductCode = Product.Code
            Me.ProductName = Product.Name

            Me.IsActive = True

            If Product.Client.IsActive.GetValueOrDefault(0) = 0 Then

                Me.IsActive = False

            ElseIf Product.Division.IsActive.GetValueOrDefault(0) = 0 Then

                Me.IsActive = False

            ElseIf Product.IsActive.GetValueOrDefault(0) = 0 Then

                Me.IsActive = False

            End If

        End Sub
        Public Sub New(Product As AdvantageFramework.Database.Views.ProductView)

            Me.CDPSecurityGroupID = 0
            Me.OfficeCode = Product.OfficeCode
            Me.OfficeName = Product.OfficeName
            Me.ClientCode = Product.ClientCode
            Me.ClientName = Product.ClientName
            Me.DivisionCode = Product.DivisionCode
            Me.DivisionName = Product.DivisionName
            Me.ProductCode = Product.ProductCode
            Me.ProductName = Product.ProductDescription
            Me.IsActive = Product.IsActive.GetValueOrDefault(0)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode & " - " & Me.DivisionCode & " - " & Me.ProductCode

        End Function

#End Region

    End Class

End Namespace
