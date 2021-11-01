Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class EmployeeAssignment
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            SequenceNumber
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            TaskDescription
            TaskStartDate
            JobRevisedDate
            JobHours
            AdjustedJobHours
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _EmployeeCode As String = Nothing
        Private _SequenceNumber As Integer = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _TaskDescription As String = Nothing
        Private _TaskStartDate As Nullable(Of DateTime) = Nothing
        Private _JobRevisedDate As Nullable(Of DateTime) = Nothing
        Private _JobHours As Nullable(Of Decimal) = Nothing
        Private _AdjustedJobHours As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        Public Property ID As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        Public Property SequenceNumber As Integer
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Integer)
                _SequenceNumber = value
            End Set
        End Property
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property JobNumber As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        Public Property JobDescription As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property JobComponentNumber As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        Public Property JobComponentDescription As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        Public Property TaskDescription As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set(value As String)
                _TaskDescription = value
            End Set
        End Property
        Public Property TaskStartDate As Nullable(Of DateTime)
            Get
                TaskStartDate = _TaskStartDate
            End Get
            Set(value As Nullable(Of DateTime))
                _TaskStartDate = value
            End Set
        End Property
        Public Property JobRevisedDate As Nullable(Of DateTime)
            Get
                JobRevisedDate = _JobRevisedDate
            End Get
            Set(value As Nullable(Of DateTime))
                _JobRevisedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="N2")>
        Public Property JobHours As Nullable(Of Decimal)
            Get
                JobHours = _JobHours
            End Get
            Set(value As Nullable(Of Decimal))
                _JobHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="N2")>
        Public Property AdjustedJobHours As Nullable(Of Decimal)
            Get
                AdjustedJobHours = _AdjustedJobHours
            End Get
            Set(value As Nullable(Of Decimal))
                _AdjustedJobHours = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace


