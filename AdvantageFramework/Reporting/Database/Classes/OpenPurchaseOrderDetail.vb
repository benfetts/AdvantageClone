Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class OpenPurchaseOrderDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            POType
            PONumber
            POLineNumber
            PODate
            PODueDate
            PODescription
            POLineDescription
            UserID
            EmployeeCode
            EmployeeName
            VendorCode
            VendorName
            VendorOfficeCode
            VendorOfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            JobStatus
            FunctionCode
            FunctionDescription
            AccountCode
            AccountDescription
            POQuantity
            PORate
            PONetAmount
            POMarkup
            POTotalAmount
            APNetAmount
            APMarkupAmount
            APGrossAmount
            BilledAPNet
            BilledAPGross
            PONetBalance
            POGrossBalance
            APInvoiceNumbers
            POComplete
            APPOComplete
            POStatus
            Voided
            POWorkComplete
            POApproved
            POApprovedBy
            POApprovedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid

        Public Property POType As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property PONumber As Nullable(Of Integer) 'PurchaseOrderNumber

        Public Property POLineNumber As Integer
        Public Property PODate As Date
        Public Property PODueDate As Nullable(Of Date)
        Public Property PODescription As String
        Public Property POLineDescription As String

        Public Property UserID As String
        Public Property EmployeeCode As String
        Public Property EmployeeName As String

        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property VendorOfficeCode As String
        Public Property VendorOfficeName As String
        Public Property ClientCode As String
        Public Property ClientName As String
        Public Property DivisionCode As String
        Public Property DivisionName As String
        Public Property ProductCode As String
        Public Property ProductName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber As Nullable(Of Integer)

        Public Property JobDescription As String
        Public Property JobComponentNumber As Nullable(Of Short)
        Public Property JobComponentDescription As String
        Public Property JobStatus As String
        Public Property FunctionCode As String
        Public Property FunctionDescription As String
        Public Property AccountCode As String
        Public Property AccountDescription As String

        Public Property POQuantity As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property PORate As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PONetAmount As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property POMarkup As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property POTotalAmount As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APNetAmount As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APMarkupAmount As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APGrossAmount As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledAPNet As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledAPGross As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PONetBalance As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property POGrossBalance As Decimal

        Public Property APInvoiceNumbers As String
        Public Property POComplete As String
        Public Property APPOComplete As String
        Public Property POStatus As String
        Public Property Voided As String
        Public Property POWorkComplete As String

        Public Property POApproved As String
        Public Property POApprovedBy As String
        Public Property POApprovedDate As Nullable(Of Date)


#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
