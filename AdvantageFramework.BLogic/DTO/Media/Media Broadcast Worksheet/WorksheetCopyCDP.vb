Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetCopyCDP
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
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
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.ClientCode)>
        Public Property OfficeCode() As String
        Public Property OfficeName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        Public Property ClientName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        Public Property DivisionName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
        Public Property ProductName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.OfficeCode = String.Empty
            Me.OfficeName = String.Empty
            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.DivisionName = String.Empty
            Me.ProductCode = String.Empty
            Me.ProductName = String.Empty

        End Sub
        Public Sub New(Product As AdvantageFramework.Database.Entities.Product)

            Me.OfficeCode = Product.OfficeCode
            Me.OfficeName = Product.Office.Name
            Me.ClientCode = Product.ClientCode
            Me.ClientName = Product.Client.Name
            Me.DivisionCode = Product.DivisionCode
            Me.DivisionName = Product.Division.Name
            Me.ProductCode = Product.Code
            Me.ProductName = Product.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode & " - " & Me.DivisionCode & " - " & Me.ProductCode

        End Function

#End Region

    End Class

End Namespace
