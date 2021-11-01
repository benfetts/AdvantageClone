Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ScheduleTask
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobComponentNumber
            SequenceNumber
            TaskCode
            TaskDescription
            TaskStatus
            EmployeeCode
            EstimateFunction
            TaskStartDate
            JobRevisedDate
            JobCompletedDate
            JobDueDate
            RevisedDueTime
            TemporaryCompleteDate
            TrafficPhaseID
            PhaseOrder
            PhaseDescription
            JobOrder
            JobDays
            JobHours
            DueTime
            Milestone
            Predecessor
            DueDateLock
            FunctionComments
            DueDateComments
            RevisionDateComments
            DispersedHours
            TrafficRole
            FunctionDescription
            HasAssignment
            HasAlerts
            PostedHours
            PercentComplete
            PhaseStartDate
            PhaseEndDate
            ClientContact
            ParentTaskSequenceNumber
            IsLinked
            GridOrder
            Level
            HasDocuments
            HasChildren
            HasPredecessors
            PredecessorLevelNotation
            PredecessorList
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _TaskCode As String = Nothing
        Private _TaskDescription As String = Nothing
        Private _TaskStatus As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EstimateFunction As String = Nothing
        Private _TaskStartDate As Nullable(Of Date) = Nothing
        Private _JobRevisedDate As Nullable(Of Date) = Nothing
        Private _JobCompletedDate As Nullable(Of DateTime) = Nothing
        Private _JobDueDate As Nullable(Of DateTime) = Nothing
        Private _RevisedDueTime As String = Nothing
        Private _TemporaryCompleteDate As Nullable(Of DateTime) = Nothing
        Private _TrafficPhaseID As Nullable(Of Integer) = Nothing
        Private _PhaseOrder As Integer = Nothing
        Private _PhaseDescription As String = Nothing
        Private _JobOrder As Nullable(Of Short) = Nothing
        Private _JobDays As Nullable(Of Short) = Nothing
        Private _JobHours As Nullable(Of Decimal) = Nothing
        Private _DueTime As String = Nothing
        Private _Milestone As Nullable(Of Short) = Nothing
        Private _Predecessor As Short? = Nothing
        Private _DueDateLock As Short = Nothing
        Private _FunctionComments As String = Nothing
        Private _DueDateComments As String = Nothing
        Private _RevisionDateComments As String = Nothing
        Private _DispersedHours As Decimal = Nothing
        Private _TrafficRole As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _HasAssignment As Integer = Nothing
        Private _HasAlerts As Integer = Nothing
        Private _PostedHours As Nullable(Of Decimal) = Nothing
        Private _PercentComplete As Nullable(Of Decimal) = Nothing
        Private _PhaseStartDate As Nullable(Of Date) = Nothing
        Private _PhaseEndDate As Nullable(Of Date) = Nothing
        Private _ClientContact As String = Nothing
        Private _ParentTaskSequenceNumber As Short? = Nothing
        Private _IsLinked As Boolean? = Nothing
        Private _GridOrder As Short? = Nothing
        Private _Level As String = Nothing
        Private _HasDocuments As Boolean = False
        Private _HasChildren As Boolean = False
        Private _HasPredecessors As Boolean = False
        Private _PredecessorLevelNotation As String = Nothing
        Private _PredecessorSequenceNumbers As Short() = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="", PropertyType:=BaseClasses.PropertyTypes.TaskCode)>
        Public Property TaskCode() As String
            Get
                TaskCode = _TaskCode
            End Get
            Set(value As String)
                _TaskCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property TaskDescription() As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set(value As String)
                _TaskDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="M/S", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property Milestone() As Nullable(Of Short)
            Get
                Milestone = _Milestone
            End Get
            Set(value As Nullable(Of Short))
                _Milestone = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Employee(s)")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Order")>
        Public Property JobOrder() As Nullable(Of Short)
            Get
                JobOrder = _JobOrder
            End Get
            Set(value As Nullable(Of Short))
                _JobOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Days")>
        Public Property JobDays() As Nullable(Of Short)
            Get
                JobDays = _JobDays
            End Get
            Set(value As Nullable(Of Short))
                _JobDays = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Default Hours")>
        Public Property DispersedHours() As Decimal
            Get
                DispersedHours = _DispersedHours
            End Get
            Set(value As Decimal)
                _DispersedHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Start Date")>
        Public Property TaskStartDate() As Nullable(Of Date)
            Get
                TaskStartDate = _TaskStartDate
            End Get
            Set(value As Nullable(Of Date))
                _TaskStartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Due Date")>
        Public Property JobRevisedDate() As Nullable(Of Date)
            Get
                JobRevisedDate = _JobRevisedDate
            End Get
            Set(value As Nullable(Of Date))
                _JobRevisedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Time Due")>
        Public Property RevisedDueTime() As String
            Get
                RevisedDueTime = _RevisedDueTime
            End Get
            Set(value As String)
                _RevisedDueTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Original Due Date")>
        Public Property JobDueDate() As Nullable(Of DateTime)
            Get
                JobDueDate = _JobDueDate
            End Get
            Set(value As Nullable(Of DateTime))
                _JobDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Original Time Due")>
        Public Property DueTime() As String
            Get
                DueTime = _DueTime
            End Get
            Set(value As String)
                _DueTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Date Completed")>
        Public Property JobCompletedDate() As Nullable(Of DateTime)
            Get
                JobCompletedDate = _JobCompletedDate
            End Get
            Set(value As Nullable(Of DateTime))
                _JobCompletedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="", PropertyType:=BaseClasses.PropertyTypes.EmployeeFunctionCode)>
        Public Property EstimateFunction() As String
            Get
                EstimateFunction = _EstimateFunction
            End Get
            Set(value As String)
                _EstimateFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property TaskStatus() As String
            Get
                TaskStatus = _TaskStatus
            End Get
            Set(value As String)
                _TaskStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Lock", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property DueDateLock() As Short
            Get
                DueDateLock = _DueDateLock
            End Get
            Set(value As Short)
                _DueDateLock = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Task Comments", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property DueDateComments() As String
            Get
                DueDateComments = _DueDateComments
            End Get
            Set(value As String)
                _DueDateComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Revised Date Comments", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property RevisionDateComments() As String
            Get
                RevisionDateComments = _RevisionDateComments
            End Get
            Set(value As String)
                _RevisionDateComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property PostedHours() As Nullable(Of Decimal)
            Get
                PostedHours = _PostedHours
            End Get
            Set(value As Nullable(Of Decimal))
                _PostedHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property TemporaryCompleteDate() As Nullable(Of DateTime)
            Get
                TemporaryCompleteDate = _TemporaryCompleteDate
            End Get
            Set(value As Nullable(Of DateTime))
                _TemporaryCompleteDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="", PropertyType:=BaseClasses.PropertyTypes.Phase)>
        Public Property TrafficPhaseID() As Nullable(Of Integer)
            Get
                TrafficPhaseID = _TrafficPhaseID
            End Get
            Set(value As Nullable(Of Integer))
                If value.GetValueOrDefault(0) = 0 Then
                    _TrafficPhaseID = Nothing
                Else
                    _TrafficPhaseID = value
                End If
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property PhaseOrder() As Integer
            Get
                PhaseOrder = _PhaseOrder
            End Get
            Set(value As Integer)
                _PhaseOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property PhaseDescription() As String
            Get
                PhaseDescription = _PhaseDescription
            End Get
            Set(value As String)
                _PhaseDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property JobHours() As Nullable(Of Decimal)
            Get
                JobHours = _JobHours
            End Get
            Set(value As Nullable(Of Decimal))
                _JobHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property Predecessor() As Short?
            Get
                Predecessor = _Predecessor
            End Get
            Set(value As Short?)
                _Predecessor = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property FunctionComments() As String
            Get
                FunctionComments = _FunctionComments
            End Get
            Set(value As String)
                _FunctionComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property TrafficRole() As String
            Get
                TrafficRole = _TrafficRole
            End Get
            Set(value As String)
                _TrafficRole = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property HasAssignment() As Integer
            Get
                HasAssignment = _HasAssignment
            End Get
            Set(value As Integer)
                _HasAssignment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property HasAlerts() As Integer
            Get
                HasAlerts = _HasAlerts
            End Get
            Set(value As Integer)
                _HasAlerts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property PercentComplete() As Nullable(Of Decimal)
            Get
                PercentComplete = _PercentComplete
            End Get
            Set(value As Nullable(Of Decimal))
                _PercentComplete = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property PhaseStartDate() As Nullable(Of Date)
            Get
                PhaseStartDate = _PhaseStartDate
            End Get
            Set(value As Nullable(Of Date))
                _PhaseStartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property PhaseEndDate() As Nullable(Of Date)
            Get
                PhaseEndDate = _PhaseEndDate
            End Get
            Set(value As Nullable(Of Date))
                _PhaseEndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="")>
        Public Property ClientContact() As String
            Get
                ClientContact = _ClientContact
            End Get
            Set(value As String)
                _ClientContact = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property ParentTaskSequenceNumber() As Short?
            Get
                ParentTaskSequenceNumber = _ParentTaskSequenceNumber
            End Get
            Set(value As Short?)
                _ParentTaskSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property GridOrder() As Short?
            Get
                GridOrder = _GridOrder
            End Get
            Set(value As Short?)
                _GridOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property Level() As String
            Get
                Level = _Level
            End Get
            Set(value As String)
                _Level = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property HasDocuments() As Boolean
            Get
                HasDocuments = _HasDocuments
            End Get
            Set(value As Boolean)
                _HasDocuments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property HasChildren() As Boolean
            Get
                HasChildren = _HasChildren
            End Get
            Set(value As Boolean)
                _HasChildren = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property HasPredecessors() As Boolean
            Get
                HasPredecessors = _HasPredecessors
            End Get
            Set(value As Boolean)
                _HasPredecessors = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property PredecessorLevelNotation() As String
            Get
                PredecessorLevelNotation = _PredecessorLevelNotation
            End Get
            Set(value As String)
                _PredecessorLevelNotation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property PredecessorSequenceNumbers() As Short()
            Get
                PredecessorSequenceNumbers = _PredecessorSequenceNumbers
            End Get
            Set(value As Short())
                _PredecessorSequenceNumbers = value
            End Set
        End Property

        Public Property ClientContactName As String
        Public Property EmployeeName As String
        Public Property AlertId As Integer
        Public Property Priority As Short

        <NotMapped>
        Public ReadOnly Property TempCompleteDateString
            Get

                Dim s As String = ""
                Try

                    If TemporaryCompleteDate IsNot Nothing Then

                        s = CType(TemporaryCompleteDate, Date).ToShortDateString

                    End If

                Catch ex As Exception
                    s = ""
                End Try

                Return s

            End Get
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        'Public Property IsLinked() As Boolean?
        '    Get
        '        IsLinked = _IsLinked
        '    End Get
        '    Set(value As Boolean?)
        '        _IsLinked = value
        '    End Set
        'End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyValue As Object = Nothing
            Dim ErrorText As String = Nothing
            Dim EmployeeCodeValid As Boolean = True

            PropertyValue = Value

            If PropertyName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EmployeeCode.ToString Then

                If PropertyValue IsNot Nothing Then

                    Try

                        For Each PropValue In DirectCast(PropertyValue, String).Replace(" ", "").Split(",")

                            AdvantageFramework.BaseClasses.ValidatePropertyType(Me.DbContext, Me.DataContext, AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCode, PropValue, EmployeeCodeValid)

                            If EmployeeCodeValid = False Then

                                IsValid = False
                                ErrorText &= PropValue & " is not a valid employee code. "

                            End If

                            EmployeeCodeValid = True

                        Next

                    Catch ex As Exception

                    End Try

                End If

            End If

            _ErrorHashtable(PropertyName) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function

#End Region

    End Class

End Namespace
