Namespace DTO.FinanceAndAccounting

    Public Class ClientLateFeeInvoice
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
            AmountDue
            LateFeePercent
            LateFee
            LateFeeGLAccount
            PostPeriod
            CreateInvoice
            InvoiceCreatedForPostPeriod
            InvoiceNumber
            FeeInvoiceAmount
            InvoiceDate
            DatePosted
            EmployeeName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Office" & vbCrLf & "Code")>
        Public Property OfficeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Office" & vbCrLf & "Name")>
        Public Property OfficeName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Client" & vbCrLf & "Code")>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Client" & vbCrLf & "Name")>
        Public Property ClientName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Division" & vbCrLf & "Code")>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Division" & vbCrLf & "Name")>
        Public Property DivisionName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Product" & vbCrLf & "Code")>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Product" & vbCrLf & "Name")>
        Public Property ProductName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Amount" & vbCrLf & "Due")>
        Public Property AmountDue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Late Fee" & vbCrLf & "Percent")>
        Public Property LateFeePercent As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Late" & vbCrLf & "Fee")>
        Public Property LateFee As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Late Fee" & vbCrLf & "GL Account")>
        Public Property LateFeeGLAccount() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Post" & vbCrLf & "Period")>
        Public Property PostPeriod() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Create" & vbCrLf & "Invoice")>
        Public Property CreateInvoice() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Invoice Created" & vbCrLf & "for Post Period")>
        Public Property InvoiceCreatedForPostPeriod() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Invoice" & vbCrLf & "Number")>
        Public Property InvoiceNumber() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Fee Invoice" & vbCrLf & "Amount")>
        Public Property FeeInvoiceAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Invoice" & vbCrLf & "Date")>
        Public Property InvoiceDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Date" & vbCrLf & "Posted")>
        Public Property DatePosted() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property LateFeeLevel() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Created" & vbCrLf & "By")>
        Public Property EmployeeName() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
