Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class TaskEmployee
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobComponentNumber
            SequenceNumber
            EmployeeCode
            EmployeeName
            QuotedHours
            HoursAllowed
            HoursPosted
            TempCompleteDate
            CompletedComments
            PercentComplete
            ActualPercentComplete
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _QuotedHours As Nullable(Of Decimal) = Nothing
        Private _HoursAllowed As Nullable(Of Decimal) = Nothing
        Private _HoursPosted As Nullable(Of Decimal) = Nothing
        Private _TempCompleteDate As Nullable(Of Date) = Nothing
        Private _CompletedComments As String = Nothing
        Private _PercentComplete As Nullable(Of Decimal) = Nothing
        Private _ActualPercentComplete As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(ByVal value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Employee", IsReadOnlyColumn:=True)> _
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Employee Name")> _
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(ByVal value As String)
                _EmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="N2", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property QuotedHours() As Nullable(Of Decimal)
            Get
                QuotedHours = _QuotedHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _QuotedHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="N2", ShowColumnInGrid:=True)> _
        Public Property HoursAllowed() As Nullable(Of Decimal)
            Get
                HoursAllowed = _HoursAllowed
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _HoursAllowed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="N2", ShowColumnInGrid:=True)> _
        Public Property HoursPosted() As Nullable(Of Decimal)
            Get
                HoursPosted = _HoursPosted
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _HoursPosted = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="N2", ShowColumnInGrid:=True, CustomColumnCaption:="Gut % Complete")> _
        Public Property PercentComplete() As Nullable(Of Decimal)
            Get
                PercentComplete = _PercentComplete
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PercentComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2", ShowColumnInGrid:=True, CustomColumnCaption:="Actual % Complete")> _
        Public ReadOnly Property ActualPercentComplete() As Nullable(Of Decimal)
            Get
                ActualPercentComplete = (Me.HoursPosted.GetValueOrDefault(0) / Me.HoursAllowed.GetValueOrDefault(0)) * 100
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Completed")> _
        Public Property TempCompleteDate() As Nullable(Of Date)
            Get
                TempCompleteDate = _TempCompleteDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _TempCompleteDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Completed Comment")> _
        Public Property CompletedComments() As String
            Get
                CompletedComments = _CompletedComments
            End Get
            Set(ByVal value As String)
                _CompletedComments = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace


