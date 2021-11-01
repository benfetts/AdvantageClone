Namespace DTO.Maintenance.Accounting

    Public Class ClientDiscountExclusion
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientDiscountCode
            FunctionCode
            FunctionDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ClientDiscountCode() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property FunctionDescription() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.ClientDiscountCode = String.Empty
            Me.FunctionCode = String.Empty
            Me.FunctionDescription = String.Empty

        End Sub
        Public Sub New(ClientDiscountExclusion As AdvantageFramework.Database.Entities.ClientDiscountExclusion)

            Me.ID = ClientDiscountExclusion.ID
            Me.ClientDiscountCode = ClientDiscountExclusion.ClientDiscountCode
            Me.FunctionCode = ClientDiscountExclusion.FunctionCode
            Me.FunctionDescription = ClientDiscountExclusion.Function.Description

        End Sub
        Public Sub SaveToEntity(ByRef ClientDiscountExclusion As AdvantageFramework.Database.Entities.ClientDiscountExclusion)

            'ClientDiscountExclusion.ID = Me.ID
            ClientDiscountExclusion.ClientDiscountCode = Me.ClientDiscountCode
            ClientDiscountExclusion.FunctionCode = Me.FunctionCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.ClientDiscountCode & " - " & Me.FunctionCode

        End Function

#End Region

    End Class

End Namespace
