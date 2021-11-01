Namespace Database.Classes

    <Serializable()>
    Public Class NonbilledEmployeeTime
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeID
            EmployeeTimeDetailID
            SequenceNumber
            EmployeeCode
            EmployeeName
            EmployeeDate
            DepartmentTeamCode
            DepartmentTeamDescription
            EmployeeTitleID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            FunctionDescription
            EmployeeHours
            EmployeeNonBillableFlag
            FeeTimeFlag
            BillingRate
            TotalBill
            EmployeeTimeFlag
            EmployeeRateFrom
            EmployeeCommissionPercent
            ExtendedMarkupAmount
            TaxCode
            TaxStatePercent
            TaxCountyPercent
            TaxCityPercent
            TaxResale
            TaxCommission
            TaxCommissionOnly
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            LineTotal
            AdjusterComments
            SalesClassCode
            TaskCode
            Assignment
        End Enum

        Public Enum EmployeeTimeFlags
            Unbilled = 0
            Billed = 1
            Indirect = 2
            SelectedForBilling = 3
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeTimeID As Integer = Nothing
        Private _EmployeeTimeDetailID As Short = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _EmployeeDate As Date = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeamDescription As String = Nothing
        Private _EmployeeTitleID As Nullable(Of Integer) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _EmployeeHours As Decimal = Nothing
        Private _EmployeeNonBillableFlag As Nullable(Of Short) = Nothing
        Private _FeeTimeFlag As Nullable(Of Short) = Nothing
        Private _BillingRate As Nullable(Of Decimal) = Nothing
        Private _TotalBill As Nullable(Of Decimal) = Nothing
        Private _EmployeeTimeFlag As Integer = Nothing
        Private _EmployeeRateFrom As String = Nothing
        Private _EmployeeCommissionPercent As Nullable(Of Decimal) = Nothing
        Private _ExtendedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _TaxCode As String = Nothing
        Private _TaxStatePercent As Nullable(Of Decimal) = Nothing
        Private _TaxCountyPercent As Nullable(Of Decimal) = Nothing
        Private _TaxCityPercent As Nullable(Of Decimal) = Nothing
        Private _TaxResale As Nullable(Of Short) = Nothing
        Private _TaxCommission As Nullable(Of Short) = Nothing
        Private _TaxCommissionOnly As Nullable(Of Short) = Nothing
        Private _ExtendedStateResale As Nullable(Of Decimal) = Nothing
        Private _ExtendedCountyResale As Nullable(Of Decimal) = Nothing
        Private _ExtendedCityResale As Nullable(Of Decimal) = Nothing
        Private _LineTotal As Nullable(Of Decimal) = Nothing
        Private _AdjusterComments As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _ChangeLog As Generic.Dictionary(Of String, Boolean) = Nothing
        Private _TaskCode As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Type")>
        Public Property EmployeeTimeFlag() As Integer
            Get
                EmployeeTimeFlag = _EmployeeTimeFlag
            End Get
            Set(value As Integer)
                _EmployeeTimeFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTimeID() As Integer
            Get
                EmployeeTimeID = _EmployeeTimeID
            End Get
            Set(value As Integer)
                _EmployeeTimeID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTimeDetailID() As Short
            Get
                EmployeeTimeDetailID = _EmployeeTimeDetailID
            End Get
            Set(value As Short)
                _EmployeeTimeDetailID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee", IsReadOnlyColumn:=True)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date", IsReadOnlyColumn:=True)>
        Public Property EmployeeDate() As Date
            Get
                EmployeeDate = _EmployeeDate
            End Get
            Set(value As Date)
                _EmployeeDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Dept / Team", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Dept / Team Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DepartmentTeamName)>
        Public Property DepartmentTeamDescription() As String
            Get
                DepartmentTeamDescription = _DepartmentTeamDescription
            End Get
            Set(value As String)
                _DepartmentTeamDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee Title", PropertyType:=BaseClasses.PropertyTypes.EmployeeTitleID)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
            Get
                EmployeeTitleID = _EmployeeTitleID
            End Get
            Set(value As Nullable(Of Integer))
                _EmployeeTitleID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product Name", IsReadOnlyColumn:=True)>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job", IsReadOnlyColumn:=True)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp", IsReadOnlyColumn:=True)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp Description", IsReadOnlyColumn:=True)>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function", IsReadOnlyColumn:=True)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.TaskCode)>
        Public Property TaskCode() As String
            Get
                TaskCode = _TaskCode
            End Get
            Set(value As String)
                _TaskCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Hours", IsReadOnlyColumn:=True)>
        Public Property EmployeeHours() As Decimal
            Get
                EmployeeHours = _EmployeeHours
            End Get
            Set(value As Decimal)
                _EmployeeHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billable", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
        Public Property EmployeeNonBillableFlag() As Nullable(Of Short)
            Get
                EmployeeNonBillableFlag = _EmployeeNonBillableFlag
            End Get
            Set(value As Nullable(Of Short))
                _EmployeeNonBillableFlag = value
                SetPropertyAutomaticallyChanged("EmployeeNonBillableFlag", False)
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="")>
        Public Property FeeTimeFlag() As Nullable(Of Short)
            Get
                FeeTimeFlag = _FeeTimeFlag
            End Get
            Set(value As Nullable(Of Short))
                _FeeTimeFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="", DisplayFormat:="n2")>
        Public Property BillingRate() As Nullable(Of Decimal)
            Get
                BillingRate = _BillingRate
            End Get
            Set(value As Nullable(Of Decimal))
                _BillingRate = value
                SetPropertyAutomaticallyChanged("BillingRate", False)
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Total", IsReadOnlyColumn:=True, DisplayFormat:="n2")>
        Public Property TotalBill() As Nullable(Of Decimal)
            Get
                TotalBill = _TotalBill
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="", PropertyType:=BaseClasses.Methods.PropertyTypes.Assignment)>
        Public Property Assignment() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeRateFrom() As String
            Get
                EmployeeRateFrom = _EmployeeRateFrom
            End Get
            Set(value As String)
                _EmployeeRateFrom = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCommissionPercent() As Nullable(Of Decimal)
            Get
                EmployeeCommissionPercent = _EmployeeCommissionPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _EmployeeCommissionPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtendedMarkupAmount = _ExtendedMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxStatePercent() As Nullable(Of Decimal)
            Get
                TaxStatePercent = _TaxStatePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxStatePercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCountyPercent() As Nullable(Of Decimal)
            Get
                TaxCountyPercent = _TaxCountyPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxCountyPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCityPercent() As Nullable(Of Decimal)
            Get
                TaxCityPercent = _TaxCityPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxCityPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxResale() As Nullable(Of Short)
            Get
                TaxResale = _TaxResale
            End Get
            Set(value As Nullable(Of Short))
                _TaxResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCommission() As Nullable(Of Short)
            Get
                TaxCommission = _TaxCommission
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommission = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCommissionOnly() As Nullable(Of Short)
            Get
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionOnly = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedStateResale() As Nullable(Of Decimal)
            Get
                ExtendedStateResale = _ExtendedStateResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedStateResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCountyResale() As Nullable(Of Decimal)
            Get
                ExtendedCountyResale = _ExtendedCountyResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCountyResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCityResale() As Nullable(Of Decimal)
            Get
                ExtendedCityResale = _ExtendedCityResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCityResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineTotal() As Nullable(Of Decimal)
            Get
                LineTotal = _LineTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _LineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AdjusterComments() As String
            Get
                AdjusterComments = _AdjusterComments
            End Get
            Set(value As String)
                _AdjusterComments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(ByVal NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex)

            _EmployeeTimeID = NonbilledEmployeeTime.EmployeeTimeID
            _EmployeeTimeDetailID = NonbilledEmployeeTime.EmployeeTimeDetailID
            _SequenceNumber = NonbilledEmployeeTime.SequenceNumber
            _EmployeeCode = NonbilledEmployeeTime.EmployeeCode
            _EmployeeName = NonbilledEmployeeTime.EmployeeName
            _EmployeeDate = NonbilledEmployeeTime.EmployeeDate
            _DepartmentTeamCode = NonbilledEmployeeTime.DepartmentTeamCode
            _DepartmentTeamDescription = NonbilledEmployeeTime.DepartmentTeamDescription
            _EmployeeTitleID = NonbilledEmployeeTime.EmployeeTitleID
            _ClientCode = NonbilledEmployeeTime.ClientCode
            _ClientName = NonbilledEmployeeTime.ClientName
            _DivisionCode = NonbilledEmployeeTime.DivisionCode
            _DivisionName = NonbilledEmployeeTime.DivisionName
            _ProductCode = NonbilledEmployeeTime.ProductCode
            _ProductDescription = NonbilledEmployeeTime.ProductDescription
            _JobNumber = NonbilledEmployeeTime.JobNumber
            _JobDescription = NonbilledEmployeeTime.JobDescription
            _JobComponentNumber = NonbilledEmployeeTime.JobComponentNumber
            _JobComponentDescription = NonbilledEmployeeTime.JobComponentDescription
            _FunctionCode = NonbilledEmployeeTime.FunctionCode
            _FunctionDescription = NonbilledEmployeeTime.FunctionDescription
            _EmployeeHours = NonbilledEmployeeTime.EmployeeHours
            _EmployeeNonBillableFlag = NonbilledEmployeeTime.EmployeeNonBillableFlag
            _FeeTimeFlag = NonbilledEmployeeTime.FeeTimeFlag
            _BillingRate = NonbilledEmployeeTime.BillingRate
            _TotalBill = NonbilledEmployeeTime.TotalBill
            _EmployeeTimeFlag = NonbilledEmployeeTime.EmployeeTimeFlag
            _EmployeeRateFrom = NonbilledEmployeeTime.EmployeeRateFrom
            _EmployeeCommissionPercent = NonbilledEmployeeTime.EmployeeCommissionPercent
            _ExtendedMarkupAmount = NonbilledEmployeeTime.ExtendedMarkupAmount
            _TaxCode = NonbilledEmployeeTime.TaxCode
            _TaxStatePercent = NonbilledEmployeeTime.TaxStatePercent
            _TaxCountyPercent = NonbilledEmployeeTime.TaxCountyPercent
            _TaxCityPercent = NonbilledEmployeeTime.TaxCityPercent
            _TaxResale = NonbilledEmployeeTime.TaxResale
            _TaxCommission = NonbilledEmployeeTime.TaxCommission
            _TaxCommissionOnly = NonbilledEmployeeTime.TaxCommissionOnly
            _ExtendedStateResale = NonbilledEmployeeTime.ExtendedStateResale
            _ExtendedCountyResale = NonbilledEmployeeTime.ExtendedCountyResale
            _ExtendedCityResale = NonbilledEmployeeTime.ExtendedCityResale
            _LineTotal = NonbilledEmployeeTime.LineTotal
            _AdjusterComments = NonbilledEmployeeTime.AdjusterComments
            _SalesClassCode = NonbilledEmployeeTime.SalesClassCode
            _TaskCode = NonbilledEmployeeTime.TaskCode
            _Assignment = NonbilledEmployeeTime.Assignment

        End Sub
        Public Sub SetPropertyAutomaticallyChanged(ByVal PropertyName As String, ByVal AutomaticallyChanged As Boolean)

            If _ChangeLog Is Nothing Then

                _ChangeLog = New Generic.Dictionary(Of String, Boolean)

            End If

            _ChangeLog(PropertyName.ToString) = AutomaticallyChanged

        End Sub
        Public Function GetPropertyAutomaticallyChanged(ByVal PropertyName As String) As Boolean

            'objects
            Dim AutomaticallyChanged As Boolean = False

            If _ChangeLog IsNot Nothing Then

                If _ChangeLog.ContainsKey(PropertyName.ToString) Then

                    AutomaticallyChanged = _ChangeLog(PropertyName.ToString)

                End If

            End If

            GetPropertyAutomaticallyChanged = AutomaticallyChanged

        End Function
        Public Overrides Sub SetRequiredFields()

            'objects
            Dim FieldsRequired As Boolean = False

            If Me.EmployeeTimeFlag <> AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Indirect Then

                FieldsRequired = True

            End If

            SetRequired(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FeeTimeFlag.ToString, FieldsRequired)
            SetRequired(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.BillingRate.ToString, FieldsRequired)
            SetRequired(AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.DepartmentTeamCode.ToString, FieldsRequired)

        End Sub
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            SetRequiredFields()

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function

#End Region

    End Class

End Namespace

