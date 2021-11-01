Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="EmployeeTimeComplex")>
    <Serializable()>
    Public Class EmployeeTimeComplex
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeID
            EmployeeTimeDetailID
            FunctionCategory
            FunctionCategoryDescription
            EmployeeHours
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            ClientReference
            JobComponentNumber
            DepartmentTeamCode
            TimeType
            EditFlag
            MaxSequence
            StartTime
            EndTime
            EmployeeDate
            Comments
            JobDescription
            JobComponentDescription
            ProductCategoryCode
            ClientName
            DivisionName
            ProductDescription
            JobProcessControl
            NonEditMessage
            IsLockedByProcessControl
            HasStopwatch
            StopwatchEmployeeTimeID
            StopwatchEmployeeTimeDetailID
            CommentsRequired
            DayIsDenied
            DayIsApproved
            DayIsPendingApproval
            DayPostPeriodClosed
            CreateDate
            ClientCommentRequired
            TimesheetMissingComments
            Quoted
            Actual
            QuotedHours
            ActualHours
            IsOverThreshold
            ProgressIsShowingTrafficHours
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeTimeID As Integer = Nothing
        Private _EmployeeTimeDetailID As Integer = Nothing
        Private _FunctionCategory As String = Nothing
        Private _FunctionCategoryDescription As String = Nothing
        Private _EmployeeHours As Decimal = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _ClientReference As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _TimeType As String = Nothing
        Private _EditFlag As Short = Nothing
        Private _MaxSequence As Nullable(Of Short) = Nothing
        Private _StartTime As String = Nothing
        Private _EndTime As String = Nothing
        Private _EmployeeDate As Nullable(Of Date) = Nothing
        Private _Comments As String = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _ProductCategoryCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobProcessControl As Nullable(Of Integer) = Nothing
        Private _NonEditMessage As String = Nothing
        Private _IsLockedByProcessControl As Nullable(Of Short) = Nothing
        Private _HasStopwatch As Nullable(Of Integer) = Nothing
        Private _StopwatchEmployeeTimeID As Nullable(Of Integer) = Nothing
        Private _StopwatchEmployeeTimeDetailID As Nullable(Of Integer) = Nothing
        Private _CommentsRequired As Nullable(Of Integer) = Nothing
        Private _DayIsDenied As Nullable(Of Boolean) = Nothing
        Private _DayIsApproved As Nullable(Of Boolean) = Nothing
        Private _DayIsPendingApproval As Nullable(Of Boolean) = Nothing
        Private _DayPostPeriodClosed As Nullable(Of Boolean) = Nothing
        Private _CreateDate As Nullable(Of Date) = Nothing
        Private _ClientCommentRequired As Nullable(Of Boolean) = Nothing
        Private _TimesheetMissingComments As Nullable(Of Boolean) = Nothing
        Private _Quoted As Nullable(Of Decimal) = Nothing
        Private _Actual As Nullable(Of Decimal) = Nothing
        Private _QuotedHours As Nullable(Of Decimal) = Nothing
        Private _ActualHours As Nullable(Of Decimal) = Nothing
        Private _IsOverThreshold As Nullable(Of Boolean) = Nothing
        Private _ProgressIsShowingTrafficHours As Nullable(Of Boolean) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeTimeID() As Integer
            Get
                EmployeeTimeID = _EmployeeTimeID
            End Get
            Set(value As Integer)
                _EmployeeTimeID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeTimeDetailID() As Integer
            Get
                EmployeeTimeDetailID = _EmployeeTimeDetailID
            End Get
            Set(value As Integer)
                _EmployeeTimeDetailID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionCategory() As String
            Get
                FunctionCategory = _FunctionCategory
            End Get
            Set(value As String)
                _FunctionCategory = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionCategoryDescription() As String
            Get
                FunctionCategoryDescription = _FunctionCategoryDescription
            End Get
            Set(value As String)
                _FunctionCategoryDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeHours() As Decimal
            Get
                EmployeeHours = _EmployeeHours
            End Get
            Set(value As Decimal)
                _EmployeeHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(value As String)
                _ClientReference = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TimeType() As String
            Get
                TimeType = _TimeType
            End Get
            Set(value As String)
                _TimeType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EditFlag() As Short
            Get
                EditFlag = _EditFlag
            End Get
            Set(value As Short)
                _EditFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaxSequence() As Nullable(Of Short)
            Get
                MaxSequence = _MaxSequence
            End Get
            Set(value As Nullable(Of Short))
                _MaxSequence = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartTime() As String
            Get
                StartTime = _StartTime
            End Get
            Set(value As String)
                _StartTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndTime() As String
            Get
                EndTime = _EndTime
            End Get
            Set(value As String)
                _EndTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeDate() As Nullable(Of Date)
            Get
                EmployeeDate = _EmployeeDate
            End Get
            Set(value As Nullable(Of Date))
                _EmployeeDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Comments() As String
            Get
                Comments = _Comments
            End Get
            Set(value As String)
                _Comments = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCategoryCode() As String
            Get
                ProductCategoryCode = _ProductCategoryCode
            End Get
            Set(value As String)
                _ProductCategoryCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobProcessControl() As Nullable(Of Integer)
            Get
                JobProcessControl = _JobProcessControl
            End Get
            Set(value As Nullable(Of Integer))
                _JobProcessControl = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonEditMessage() As String
            Get
                NonEditMessage = _NonEditMessage
            End Get
            Set(value As String)
                _NonEditMessage = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsLockedByProcessControl() As Nullable(Of Short)
            Get
                IsLockedByProcessControl = _IsLockedByProcessControl
            End Get
            Set(value As Nullable(Of Short))
                _IsLockedByProcessControl = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HasStopwatch() As Nullable(Of Integer)
            Get
                HasStopwatch = _HasStopwatch
            End Get
            Set(value As Nullable(Of Integer))
                _HasStopwatch = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StopwatchEmployeeTimeID() As Nullable(Of Integer)
            Get
                StopwatchEmployeeTimeID = _StopwatchEmployeeTimeID
            End Get
            Set(value As Nullable(Of Integer))
                _StopwatchEmployeeTimeID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StopwatchEmployeeTimeDetailID() As Nullable(Of Integer)
            Get
                StopwatchEmployeeTimeDetailID = _StopwatchEmployeeTimeDetailID
            End Get
            Set(value As Nullable(Of Integer))
                _StopwatchEmployeeTimeDetailID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommentsRequired() As Nullable(Of Integer)
            Get
                CommentsRequired = _CommentsRequired
            End Get
            Set(value As Nullable(Of Integer))
                _CommentsRequired = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DayIsDenied() As Nullable(Of Boolean)
            Get
                DayIsDenied = _DayIsDenied
            End Get
            Set(value As Nullable(Of Boolean))
                _DayIsDenied = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DayIsApproved() As Nullable(Of Boolean)
            Get
                DayIsApproved = _DayIsApproved
            End Get
            Set(value As Nullable(Of Boolean))
                _DayIsApproved = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DayIsPendingApproval() As Nullable(Of Boolean)
            Get
                DayIsPendingApproval = _DayIsPendingApproval
            End Get
            Set(value As Nullable(Of Boolean))
                _DayIsPendingApproval = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DayPostPeriodClosed() As Nullable(Of Boolean)
            Get
                DayPostPeriodClosed = _DayPostPeriodClosed
            End Get
            Set(value As Nullable(Of Boolean))
                _DayPostPeriodClosed = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CreateDate() As Nullable(Of Date)
            Get
                CreateDate = _CreateDate
            End Get
            Set(value As Nullable(Of Date))
                _CreateDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCommentRequired() As Nullable(Of Boolean)
            Get
                ClientCommentRequired = _ClientCommentRequired
            End Get
            Set(value As Nullable(Of Boolean))
                _ClientCommentRequired = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TimesheetMissingComments() As Nullable(Of Boolean)
            Get
                TimesheetMissingComments = _TimesheetMissingComments
            End Get
            Set(value As Nullable(Of Boolean))
                _TimesheetMissingComments = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Quoted() As Nullable(Of Decimal)
            Get
                Quoted = _Quoted
            End Get
            Set(value As Nullable(Of Decimal))
                _Quoted = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Actual() As Nullable(Of Decimal)
            Get
                Actual = _Actual
            End Get
            Set(value As Nullable(Of Decimal))
                _Actual = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuotedHours() As Nullable(Of Decimal)
            Get
                QuotedHours = _QuotedHours
            End Get
            Set(value As Nullable(Of Decimal))
                _QuotedHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualHours() As Nullable(Of Decimal)
            Get
                ActualHours = _ActualHours
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsOverThreshold() As Nullable(Of Boolean)
            Get
                IsOverThreshold = _IsOverThreshold
            End Get
            Set(value As Nullable(Of Boolean))
                _IsOverThreshold = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgressIsShowingTrafficHours() As Nullable(Of Boolean)
            Get
                ProgressIsShowingTrafficHours = _ProgressIsShowingTrafficHours
            End Get
            Set(value As Nullable(Of Boolean))
                _ProgressIsShowingTrafficHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTimeID.ToString

        End Function

#End Region

    End Class

End Namespace
