Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeNotes
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            Comments
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Notes")>
        Public Property Comments As String
            Get
                Comments = _Employee.Comments
            End Get
            Set(ByVal value As String)
                _Employee.Comments = value
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