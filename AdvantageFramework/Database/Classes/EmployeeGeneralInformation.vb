Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeGeneralInformation
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            EmployeeTitleID
            Freelance
            IsActiveFreelance
            FunctionCode
            OfficeCode
            DepartmentTeamCode
            SupervisorEmployeeCode
            RoleCode
            AccountNumber
            PhoneNumber
            WorkPhoneNumber
            WorkPhoneNumberExtension
            CellPhoneNumber
            AlternatePhoneNumber
            Address
            Address2
            City
            Country
            County
            State
            Zip
            PayToAddress
            PayToAddress2
            PayToCity
            PayToCountry
            PayToCounty
            PayToState
            PayToZip
        End Enum

#End Region

#Region " Variables "

        Private _Employee As AdvantageFramework.Database.Views.Employee = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Overrides ReadOnly Property AttachedEntityType As System.Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Views.Employee)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Code)>
        Public ReadOnly Property Code() As String
            Get
                Code = _Employee.Code
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property Name() As String
            Get
                Name = _Employee.ToString
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FirstName() As String
            Get
                FirstName = _Employee.FirstName
            End Get
            Set(ByVal value As String)
                _Employee.FirstName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MiddleInitial() As String
            Get
                MiddleInitial = _Employee.MiddleInitial
            End Get
            Set(ByVal value As String)
                _Employee.MiddleInitial = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LastName() As String
            Get
                LastName = _Employee.LastName
            End Get
            Set(ByVal value As String)
                _Employee.LastName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.EmployeeTitleID, CustomColumnCaption:="Employee Title")>
        Public Property EmployeeTitleID As Nullable(Of Integer)
            Get
                EmployeeTitleID = _Employee.EmployeeTitleID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Employee.EmployeeTitleID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property Freelance As Nullable(Of Short)
            Get
                Freelance = _Employee.Freelance
            End Get
            Set(value As Nullable(Of Short))
                _Employee.Freelance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsActiveFreelance As Boolean
            Get
                IsActiveFreelance = _Employee.IsActiveFreelance
            End Get
            Set(value As Boolean)
                _Employee.IsActiveFreelance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Default Function", PropertyType:=BaseClasses.PropertyTypes.EmployeeFunctionCode)>
        Public Property FunctionCode As String
            Get
                FunctionCode = _Employee.FunctionCode
            End Get
            Set(ByVal value As String)
                _Employee.FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office", PropertyType:=BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode As String
            Get
                OfficeCode = _Employee.OfficeCode
            End Get
            Set(value As String)
                _Employee.OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Default Department / Team", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode As String
            Get
                DepartmentTeamCode = _Employee.DepartmentTeamCode
            End Get
            Set(value As String)
                _Employee.DepartmentTeamCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Supervisor", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property SupervisorEmployeeCode As String
            Get
                SupervisorEmployeeCode = _Employee.SupervisorEmployeeCode
            End Get
            Set(value As String)
                _Employee.SupervisorEmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Default Role", PropertyType:=BaseClasses.PropertyTypes.RoleCode)>
        Public Property RoleCode As String
            Get
                RoleCode = _Employee.RoleCode
            End Get
            Set(value As String)
                _Employee.RoleCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Account Number / Reference")>
        Public Property AccountNumber As String
            Get
                AccountNumber = _Employee.AccountNumber
            End Get
            Set(value As String)
                _Employee.AccountNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Home Phone Number")>
        Public Property PhoneNumber As String
            Get
                PhoneNumber = _Employee.PhoneNumber
            End Get
            Set(value As String)
                _Employee.PhoneNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property WorkPhoneNumber As String
            Get
                WorkPhoneNumber = _Employee.WorkPhoneNumber
            End Get
            Set(value As String)
                _Employee.WorkPhoneNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkPhoneNumberExtension As String
            Get
                WorkPhoneNumberExtension = _Employee.WorkPhoneNumberExtension
            End Get
            Set(value As String)
                _Employee.WorkPhoneNumberExtension = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CellPhoneNumber As String
            Get
                CellPhoneNumber = _Employee.CellPhoneNumber
            End Get
            Set(value As String)
                _Employee.CellPhoneNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AlternatePhoneNumber As String
            Get
                AlternatePhoneNumber = _Employee.AlternatePhoneNumber
            End Get
            Set(value As String)
                _Employee.AlternatePhoneNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Home Address 1")>
        Public Property Address As String
            Get
                Address = _Employee.Address
            End Get
            Set(value As String)
                _Employee.Address = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Home Address 2")>
        Public Property Address2 As String
            Get
                Address2 = _Employee.Address2
            End Get
            Set(value As String)
                _Employee.Address2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Home City")>
        Public Property City As String
            Get
                City = _Employee.City
            End Get
            Set(value As String)
                _Employee.City = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Home County")>
        Public Property County As String
            Get
                County = _Employee.County
            End Get
            Set(value As String)
                _Employee.County = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Home State")>
        Public Property State As String
            Get
                State = _Employee.State
            End Get
            Set(value As String)
                _Employee.State = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Home Zip")>
        Public Property Zip As String
            Get
                Zip = _Employee.Zip
            End Get
            Set(value As String)
                _Employee.Zip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Home Country")>
        Public Property Country As String
            Get
                Country = _Employee.Country
            End Get
            Set(value As String)
                _Employee.Country = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Mailing Address 1")>
        Public Property PayToAddress As String
            Get
                PayToAddress = _Employee.PayToAddress
            End Get
            Set(value As String)
                _Employee.PayToAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Mailing Address 2")>
        Public Property PayToAddress2 As String
            Get
                PayToAddress2 = _Employee.PayToAddress2
            End Get
            Set(value As String)
                _Employee.PayToAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Mailing City")>
        Public Property PayToCity As String
            Get
                PayToCity = _Employee.PayToCity
            End Get
            Set(value As String)
                _Employee.PayToCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Mailing County")>
        Public Property PayToCounty As String
            Get
                PayToCounty = _Employee.PayToCounty
            End Get
            Set(value As String)
                _Employee.PayToCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Mailing State")>
        Public Property PayToState As String
            Get
                PayToState = _Employee.PayToState
            End Get
            Set(value As String)
                _Employee.PayToState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Mailing Zip")>
        Public Property PayToZip As String
            Get
                PayToZip = _Employee.PayToZip
            End Get
            Set(value As String)
                _Employee.PayToZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Mailing Country")>
        Public Property PayToCountry As String
            Get
                PayToCountry = _Employee.PayToCountry
            End Get
            Set(value As String)
                _Employee.PayToCountry = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            _Employee = Employee

        End Sub
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""

            ErrorText = _Employee.ValidateEntityProperty(PropertyName, IsValid, Value)

            _ErrorHashtable(PropertyName) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function

#End Region

    End Class

End Namespace