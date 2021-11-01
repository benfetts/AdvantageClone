Namespace DTO.Maintenance.Accounting

    Public Class ClientDiscount
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            Percent
            EarlyPay
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="p0")>
        Public Property Percent() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Name = String.Empty
            Me.Percent = 0
            Me.IsInactive = False

        End Sub
        Public Sub New(ClientDiscount As AdvantageFramework.Database.Entities.ClientDiscount)

            Me.Code = ClientDiscount.Code
            Me.Name = ClientDiscount.Name
            Me.Percent = ClientDiscount.Percent
            Me.IsInactive = ClientDiscount.IsInactive

        End Sub
        Public Sub SaveToEntity(ByRef ClientDiscount As AdvantageFramework.Database.Entities.ClientDiscount)

            ClientDiscount.Code = Me.Code
            ClientDiscount.Name = Me.Name
            ClientDiscount.Percent = Me.Percent
            ClientDiscount.IsInactive = Me.IsInactive

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function

#End Region

    End Class

End Namespace
