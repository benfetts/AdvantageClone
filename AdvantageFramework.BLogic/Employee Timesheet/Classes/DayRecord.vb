Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class DayRecord
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeID
            EmployeeTimeDetailID
            IsIndirectTime
            EmployeeDate
            EmployeeHours
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobCompNumber
            FunctionCode
            DeptTeamCode
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeTimeID As Integer = Nothing
        Private _EmployeeTimeDetailID As Integer = Nothing
        Private _IsIndirectTime As Boolean = Nothing
        Private _EmployeeDate As Date = Nothing
        Private _EmployeeHours As Nullable(Of Decimal) = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobCompNumber As Nullable(Of Short) = Nothing
        Private _FunctionCode As String = Nothing
        Private _DeptTeamCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property EmployeeTimeID() As Integer
            Get
                EmployeeTimeID = _EmployeeTimeID
            End Get
            Set(value As Integer)
                _EmployeeTimeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property EmployeeTimeDetailID() As String
            Get
                EmployeeTimeDetailID = _EmployeeTimeDetailID
            End Get
            Set(value As String)
                _EmployeeTimeDetailID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsIndirectTime() As Boolean
            Get
                IsIndirectTime = _IsIndirectTime
            End Get
            Set(value As Boolean)
                _IsIndirectTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date")>
        Public Property EmployeeDate() As Date
            Get
                EmployeeDate = _EmployeeDate
            End Get
            Set(value As Date)
                _EmployeeDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Comp")>
        Public Property JobCompNumber() As Nullable(Of Short)
            Get
                JobCompNumber = _JobCompNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobCompNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Func / Cat", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Dept / Team", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DeptTeamCode() As String
            Get
                DeptTeamCode = _DeptTeamCode
            End Get
            Set(value As String)
                _DeptTeamCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Hours", ShowColumnInGrid:=False)>
        Public Property EmployeeHours() As Nullable(Of Decimal)
            Get
                EmployeeHours = _EmployeeHours
            End Get
            Set(value As Nullable(Of Decimal))
                _EmployeeHours = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace



