Namespace Database.Classes

    <Serializable()>
    Public Class DirectTime

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            Employee
            EmployeeFirstName
            EmployeeLastName
            EmployeeLastFirst
            EmployeeTitle
            EmployeeAccountNumber
            IsEmployeeFreelance
            IsActiveFreelance
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            CDPName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            JobComponent
            JobComponentName
            FunctionCode
            FunctionDescription
            [Date]
            DateEntered
            Hours
            Amount
            MarkupAmount
            ResaleTax
            TotalAmount
            TotalBilled
            TotalAmountWithTax
            TotalBilledWithTax
            NonBillable
            Billed
            FunctionHeadingDescription
            Comments
            IsFeeTime
            Rate
            UserID
            Grouping

        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _EmployeeCode As String = Nothing
        Private _Employee As String = Nothing
        Private _EmployeeFirstName As String = Nothing
        Private _EmployeeLastName As String = Nothing
        Private _EmployeeLastFirst As String = Nothing
        Private _EmployeeTitle As String = Nothing
        Private _EmployeeAccountNumber As String = Nothing
        Private _IsEmployeeFreelance As String = Nothing
        Private _IsActiveFreelance As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _CDPName As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _JobComponent As String = Nothing
        Private _JobComponentName As String = Nothing
        Private _Date As Date = Nothing
        Private _DateEntered As Nullable(Of Date) = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ResaleTax As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _TotalBilled As Nullable(Of Decimal) = Nothing
        Private _TotalAmountWithTax As Nullable(Of Decimal) = Nothing
        Private _TotalBilledWithTax As Nullable(Of Decimal) = Nothing
        Private _NonBillable As String = Nothing
        Private _Billed As String = Nothing
        Private _FunctionHeadingDescription As String = Nothing
        Private _Comments As String = Nothing
        Private _IsFeeTime As String = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _UserID As String = Nothing
        Private _Grouping As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserID() As String
            Get
                UserID = _UserID
            End Get
            Set(value As String)
                _UserID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Employee() As String
            Get
                Employee = _Employee
            End Get
            Set(ByVal value As String)
                _Employee = value
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
        Public Property EmployeeLastFirst() As String
            Get
                EmployeeLastFirst = _EmployeeLastFirst
            End Get
            Set(value As String)
                _EmployeeLastFirst = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTitle() As String
            Get
                EmployeeTitle = _EmployeeTitle
            End Get
            Set(ByVal value As String)
                _EmployeeTitle = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeAccountNumber() As String
            Get
                EmployeeAccountNumber = _EmployeeAccountNumber
            End Get
            Set(value As String)
                _EmployeeAccountNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsEmployeeFreelance() As String
            Get
                IsEmployeeFreelance = _IsEmployeeFreelance
            End Get
            Set(ByVal value As String)
                _IsEmployeeFreelance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActiveFreelance() As String
            Get
                IsActiveFreelance = _IsActiveFreelance
            End Get
            Set(value As String)
                _IsActiveFreelance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(ByVal value As String)
                _ClientDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(ByVal value As String)
                _DivisionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CDPName() As String
            Get
                CDPName = _CDPName
            End Get
            Set(ByVal value As String)
                _CDPName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentName() As String
            Get
                JobComponentName = _JobComponentName
            End Get
            Set(ByVal value As String)
                _JobComponentName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property [Date]() As Date
            Get
                [Date] = _Date
            End Get
            Set(ByVal value As Date)
                _Date = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateEntered() As Nullable(Of Date)
            Get
                DateEntered = _DateEntered
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DateEntered = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarkupAmount() As Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ResaleTax() As Nullable(Of Decimal)
            Get
                ResaleTax = _ResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalBilled() As Nullable(Of Decimal)
            Get
                TotalBilled = _TotalBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalAmountWithTax() As Nullable(Of Decimal)
            Get
                TotalAmountWithTax = _TotalAmountWithTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmountWithTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalBilledWithTax() As Nullable(Of Decimal)
            Get
                TotalBilledWithTax = _TotalBilledWithTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBilledWithTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NonBillable() As String
            Get
                NonBillable = _NonBillable
            End Get
            Set(ByVal value As String)
                _NonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Billed() As String
            Get
                Billed = _Billed
            End Get
            Set(ByVal value As String)
                _Billed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingDescription() As String
            Get
                FunctionHeadingDescription = _FunctionHeadingDescription
            End Get
            Set(ByVal value As String)
                _FunctionHeadingDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comments() As String
            Get
                Comments = _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsFeeTime() As String
            Get
                IsFeeTime = _IsFeeTime
            End Get
            Set(ByVal value As String)
                _IsFeeTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Grouping() As String
            Get
                Grouping = _Grouping
            End Get
            Set(ByVal value As String)
                _Grouping = value
            End Set
        End Property

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
