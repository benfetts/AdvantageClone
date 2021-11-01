Namespace DTO.GeneralLedger

    Public Class GeneralLedgerAccount
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            Type
            CDPRequired
            Active
            DepartmentCode
            UserCode
            EnteredDate
            ModifiedDate
            BalanceType
            BaseCode
            GeneralLedgerOfficeCrossReferenceCode
            ID
            Payroll
            PurchaseOrder
            OtherCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Code() As String
        <Required>
        <MaxLength(75)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <MaxLength(2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CDPRequired() As Nullable(Of Short)
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Active() As String
        <MaxLength(5)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentCode() As String
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EnteredDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BalanceType() As Nullable(Of Short)
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BaseCode() As String
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GeneralLedgerOfficeCrossReferenceCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Payroll() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PurchaseOrder() As Nullable(Of Short)
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OtherCode() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.Type = String.Empty
            Me.CDPRequired = Nothing
            Me.Active = "A"
            Me.DepartmentCode = Nothing
            Me.UserCode = Nothing
            Me.EnteredDate = Nothing
            Me.ModifiedDate = Nothing
            Me.BalanceType = 0
            Me.BaseCode = Nothing
            Me.GeneralLedgerOfficeCrossReferenceCode = Nothing
            Me.ID = 0
            Me.Payroll = Nothing
            Me.PurchaseOrder = Nothing
            Me.OtherCode = Nothing

        End Sub
        Public Sub New(GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            Me.Code = GeneralLedgerAccount.Code
            Me.Description = GeneralLedgerAccount.Description
            Me.Type = GeneralLedgerAccount.Type
            Me.CDPRequired = GeneralLedgerAccount.CDPRequired
            Me.Active = GeneralLedgerAccount.Active
            Me.DepartmentCode = GeneralLedgerAccount.DepartmentCode
            Me.UserCode = GeneralLedgerAccount.UserCode
            Me.EnteredDate = GeneralLedgerAccount.EnteredDate
            Me.ModifiedDate = GeneralLedgerAccount.ModifiedDate
            Me.BalanceType = GeneralLedgerAccount.BalanceType
            Me.BaseCode = GeneralLedgerAccount.BaseCode
            Me.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode
            Me.ID = GeneralLedgerAccount.ID
            Me.Payroll = GeneralLedgerAccount.Payroll
            Me.PurchaseOrder = GeneralLedgerAccount.PurchaseOrder
            Me.OtherCode = GeneralLedgerAccount.OtherCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
