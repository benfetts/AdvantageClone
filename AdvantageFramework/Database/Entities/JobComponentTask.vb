Namespace Database.Entities

	<Table("JOB_TRAFFIC_DET")>
	Public Class JobComponentTask
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            JobNumber
            JobComponentNumber
            SequenceNumber
            TaskCode
            FuctionCode
            Description
            StartDate
            OriginalDueDate
            DueDate
            IsDueDateLocked
            CompletedDate
            OrderNumber
            Days
            ParentTaskCode
            Comment
            OriginalDueDateComment
            DueDateComment
            Hours
            OriginalDueTime
            DueTime
            StatusCode
            IsMilestone
            PhaseID
            ID
            AltSequenceNumber
            RoleCode
            HoursAssigned
            EmployeeCode
            TempCompletionDate
            BoardID
            BoardColumnID
            [Function]
            JobComponent
            Role
            Phase
            Task
            ParentTask
            Employee
            JobComponentTaskEmployee
            JobComponentTaskClientContacts

        End Enum

#End Region

#Region " Variables "

        Private _StartDate As Date? = Nothing
        Private _DueDate As Date? = Nothing
        Private _OriginalDueDate As Date? = Nothing
        Private _CompletedDate As Date? = Nothing
        Private _TempCompletionDate As Date? = Nothing

#End Region

#Region " Properties "

        <Key>
		<Required>
        <Column("JOB_NUMBER", Order:=0)>
        Public Property JobNumber() As Integer
		<Key>
		<Required>
        <Column("JOB_COMPONENT_NBR", Order:=1)>
        Public Property JobComponentNumber() As Short
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=2)>
        Public Property SequenceNumber() As Short
		<MaxLength(10)>
		<Column("FNC_CODE", TypeName:="varchar")>
		Public Property TaskCode() As String
		<MaxLength(6)>
		<Column("FNC_EST", TypeName:="varchar")>
		Public Property FuctionCode() As String
		<MaxLength(40)>
		<Column("TASK_DESCRIPTION", TypeName:="varchar")>
		Public Property Description() As String

        <Column("TASK_START_DATE")>
        Public Property StartDate() As Nullable(Of Date)
            Get
                If _StartDate.HasValue Then
                    StartDate = _StartDate.Value.Date
                Else
                    StartDate = Nothing
                End If
            End Get
            Set(value As Nullable(Of Date))
                If value.HasValue Then
                    value = value.Value.Date
                End If
                _StartDate = value
            End Set
        End Property
        <Column("JOB_DUE_DATE")>
        Public Property OriginalDueDate() As Nullable(Of Date)
            Get
                If _OriginalDueDate.HasValue Then
                    OriginalDueDate = _OriginalDueDate.Value.Date
                Else
                    OriginalDueDate = Nothing
                End If
            End Get
            Set(value As Nullable(Of Date))
                If value.HasValue Then
                    value = value.Value.Date
                End If
                _OriginalDueDate = value
            End Set
        End Property
        <Column("JOB_REVISED_DATE")>
        Public Property DueDate() As Nullable(Of Date)
            Get
                If _DueDate.HasValue Then
                    DueDate = _DueDate.Value.Date
                Else
                    DueDate = Nothing
                End If
            End Get
            Set(value As Nullable(Of Date))
                If value.HasValue Then
                    value = value.Value.Date
                End If
                _DueDate = value
            End Set
        End Property
        <Column("DUE_DATE_LOCK")>
        Public Property IsDueDateLocked() As Nullable(Of Short)
        <Column("JOB_COMPLETED_DATE")>
        Public Property CompletedDate() As Nullable(Of Date)
            Get
                If _CompletedDate.HasValue Then
                    CompletedDate = _CompletedDate.Value.Date
                Else
                    CompletedDate = Nothing
                End If
            End Get
            Set(value As Nullable(Of Date))
                If value.HasValue Then
                    value = value.Value.Date
                End If
                _CompletedDate = value
            End Set
        End Property
        <Column("JOB_ORDER")>
		Public Property OrderNumber() As Nullable(Of Short)
		<Column("JOB_DAYS")>
		Public Property Days() As Nullable(Of Short)
		<MaxLength(10)>
		<Column("PARENT_TASK", TypeName:="varchar")>
		Public Property ParentTaskCode() As String
		<Column("FNC_COMMENTS")>
		Public Property Comment() As String
		<Column("DUE_DATE_COMMENTS")>
		Public Property OriginalDueDateComment() As String
		<Column("REV_DATE_COMMENTS")>
        Public Property DueDateComment() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 2)>
        <Column("JOB_HRS")>
        Public Property Hours() As Nullable(Of Decimal)
        <MaxLength(10)>
		<Column("DUE_TIME", TypeName:="varchar")>
		Public Property OriginalDueTime() As String
		<MaxLength(10)>
		<Column("REVISED_DUE_TIME", TypeName:="varchar")>
		Public Property DueTime() As String
		<MaxLength(1)>
		<Column("TASK_STATUS", TypeName:="varchar")>
		Public Property StatusCode() As String
		<Column("MILESTONE")>
		Public Property IsMilestone() As Nullable(Of Short)
		<Column("TRAFFIC_PHASE_ID")>
		Public Property PhaseID() As Nullable(Of Integer)
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		Public Property ID() As Integer
		<Column("TEMP_SEQ")>
		Public Property AltSequenceNumber() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("TRF_ROLE", TypeName:="varchar")>
		Public Property RoleCode() As String
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("HOURS_ASSIGNED")>
		Public Property HoursAssigned() As Nullable(Of Decimal)
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		Public Property EmployeeCode() As String
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
        <Column("TEMP_COMP_DATE")>
        Public Property TempCompletionDate() As Nullable(Of Date)
            Get
                If _TempCompletionDate.HasValue Then
                    TempCompletionDate = _TempCompletionDate.Value.Date
                Else
                    TempCompletionDate = Nothing
                End If
            End Get
            Set(value As Nullable(Of Date))
                If value.HasValue Then
                    value = value.Value.Date
                End If
                _TempCompletionDate = value
            End Set
        End Property
        <Column("PARENT_TASK_SEQ")>
        Public Property ParentTaskSequenceNumber() As Nullable(Of Short)
        <Column("GRID_ORDER")>
        Public Property GridOrder() As Nullable(Of Short)

        <ForeignKey("FuctionCode")>
        Public Overridable Property [Function] As Database.Entities.Function
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property Role As Database.Entities.Role
        Public Overridable Property Phase As Database.Entities.Phase
        <ForeignKey("TaskCode")>
        Public Overridable Property Task As Database.Entities.Task
        <ForeignKey("ParentTaskCode")>
        Public Overridable Property ParentTask As Database.Entities.Task
        Public Overridable Property Employee As Database.Views.Employee
        Public Overridable Property JobComponentTaskEmployee As ICollection(Of Database.Entities.JobComponentTaskEmployee)
        Public Overridable Property JobComponentTaskClientContacts As ICollection(Of Database.Entities.JobComponentTaskClientContact)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.JobComponentTask.Properties.TaskCode.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Tasks
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid task code."

                        End If

                    ElseIf String.IsNullOrWhiteSpace(Me.Description) Then

                        IsValid = False

                        ErrorText = "Task is required."

                    End If

                Case AdvantageFramework.Database.Entities.JobComponentTask.Properties.Description.ToString

                    PropertyValue = Value

                    If String.IsNullOrWhiteSpace(PropertyValue) AndAlso String.IsNullOrWhiteSpace(Me.TaskCode) Then

                        IsValid = False

                        ErrorText = "Task is required."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
