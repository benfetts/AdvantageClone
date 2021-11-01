Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet2
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EnteredStartDate
            EnteredEndDate
            CalculatedStartDate
            CalculatedEndDate
            NumberOfDays
            NumberoOfWeeks
            NumberOfMonths
            NumberOfYears
            NumberOfEmployees
        End Enum

#End Region

#Region " Variables "

        Private _EnteredStartDate As Date = Nothing
        Private _EnteredEndDate As Date = Nothing
        Private _CalculatedStartDate As Date = Nothing
        Private _CalculatedEndDate As Date = Nothing
        Private _NumberOfDays As Integer = Nothing
        Private _NumberoOfWeeks As Integer = Nothing
        Private _NumberOfMonths As Integer = Nothing
        Private _NumberOfYears As Integer = Nothing
        Private _NumberOfEmployees As Integer = Nothing

#End Region

#Region " Properties "

        Public Property EnteredStartDate As Date
            Get
                EnteredStartDate = _EnteredStartDate
            End Get
            Set(value As Date)
                _EnteredStartDate = value
            End Set
        End Property
        Public Property EnteredEndDate As Date
            Get
                EnteredEndDate = _EnteredEndDate
            End Get
            Set(value As Date)
                _EnteredEndDate = value
            End Set
        End Property
        Public Property CalculatedStartDate As Date
            Get
                CalculatedStartDate = _CalculatedStartDate
            End Get
            Set(value As Date)
                _CalculatedStartDate = value
            End Set
        End Property
        Public Property CalculatedEndDate As Date
            Get
                CalculatedEndDate = _CalculatedEndDate
            End Get
            Set(value As Date)
                _CalculatedEndDate = value
            End Set
        End Property
        Public Property NumberOfDays As Integer
            Get
                NumberOfDays = _NumberOfDays
            End Get
            Set(value As Integer)
                _NumberOfDays = value
            End Set
        End Property
        Public Property NumberoOfWeeks As Integer
            Get
                NumberoOfWeeks = _NumberoOfWeeks
            End Get
            Set(value As Integer)
                _NumberoOfWeeks = value
            End Set
        End Property
        Public Property NumberOfMonths As Integer
            Get
                NumberOfMonths = _NumberOfMonths
            End Get
            Set(value As Integer)
                _NumberOfMonths = value
            End Set
        End Property
        Public Property NumberOfYears As Integer
            Get
                NumberOfYears = _NumberOfYears
            End Get
            Set(value As Integer)
                _NumberOfYears = value
            End Set
        End Property
        Public Property NumberOfEmployees As Integer
            Get
                NumberOfEmployees = _NumberOfEmployees
            End Get
            Set(value As Integer)
                _NumberOfEmployees = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class


End Namespace

