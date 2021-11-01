Namespace Database.Classes

    <Serializable()>
    Public Class ExpenseItemImport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountNumber
            EmployeeCode
            VendorCode
            EmployeeFirstName
            EmployeeLastName
            ExpenseReportDate
            ExpenseReportDescription
            ExpenseReportDetails
            ItemDate
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobComponentNumber
            FunctionCode
            Quantity
            Rate
            Amount
            CreditCardFlag
        End Enum

#End Region

#Region " Variables "

        Private _AccountNumber As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _EmployeeFirstName As String = Nothing
        Private _EmployeeLastName As String = Nothing
        Private _ExpenseReportDate As String = Nothing
        Private _ExpenseReportDescription As String = Nothing
        Private _ExpenseReportDetails As String = Nothing
        Private _ItemDate As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As String = Nothing
        Private _JobComponentNumber As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _Quantity As String = Nothing
        Private _Rate As String = Nothing
        Private _Amount As String = Nothing
        Private _CreditCardFlag As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumber() As String
            Get
                AccountNumber = _AccountNumber
            End Get
            Set(value As String)
                _AccountNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeFirstName() As String
            Get
                EmployeeFirstName = _EmployeeFirstName
            End Get
            Set(value As String)
                _EmployeeFirstName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeLastName() As String
            Get
                EmployeeLastName = _EmployeeLastName
            End Get
            Set(value As String)
                _EmployeeLastName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpenseReportDate() As String
            Get
                ExpenseReportDate = _ExpenseReportDate
            End Get
            Set(value As String)
                _ExpenseReportDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpenseReportDescription() As String
            Get
                ExpenseReportDescription = _ExpenseReportDescription
            End Get
            Set(value As String)
                _ExpenseReportDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpenseReportDetails() As String
            Get
                ExpenseReportDetails = _ExpenseReportDetails
            End Get
            Set(value As String)
                _ExpenseReportDetails = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemDate() As String
            Get
                ItemDate = _ItemDate
            End Get
            Set(value As String)
                _ItemDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As String
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As String)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As String
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As String)
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As String
            Get
                Quantity = _Quantity
            End Get
            Set(value As String)
                _Quantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Rate() As String
            Get
                Rate = _Rate
            End Get
            Set(value As String)
                _Rate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Amount() As String
            Get
                Amount = _Amount
            End Get
            Set(value As String)
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreditCardFlag() As String
            Get
                CreditCardFlag = _CreditCardFlag
            End Get
            Set(value As String)
                _CreditCardFlag = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace