Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="CalendarItem")>
    <Serializable()>
    Public Class CalendarItem
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EMPCODE
            EMPFNAME
            EMPMI
            EMPLNAME
            EMPFMLNAME
            EMPFMLNAMEGROUP
            CLCODE
            DIVCODE
            PRDCODE
            JOBNUMBER
            JOBCOMPONENTNBR
            CLNAME
            DIVNAME
            PRDDESCRIPTION
            JOBDESC
            JOBCOMPDESC
            TASKNONTASKDISPLAY
            TASKNONTASKDESCRIPTION
            TASKSTATUS
            TASKSEQNBR
            FNCCODE
            TASKDESCRIPTION
            TASKHOURSALLOWED
            TRFCODE
            TRFDESCRIPTION
            THISDAY
            STARTDAY
            ENDDAY
            ALLDAY
            NUMDAYS
            TASKTEMPCOMPLETEDATE
            STARTDATE
            ENDDATE
            STARTTIME
            ENDTIME
            WEEKVIEWENDTIME
            HASTIME
            NONTASKID
            NONTASKTYPE
            NONTASKHOURS
            NONTASKCATEGORY
            ISNONTASK
            WEEKVIEWALLDAY
            RECTYPE
            RECORDER
            ICALID
            ADNBR
            ADNBRDESC
            ADNBRCOLOR
            RESOURCECODE
            RESOURCEDESC
            PRIORITY
            HoursAllowed
            DUETIME
            EMPDESCHRS
            REMINDER
            RECURRENCE
            RECURRENCEPARENT
            RESOURCETYPE
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _EMP_CODE As String = Nothing
        Private _EMP_FNAME As String = Nothing
        Private _EMP_MI As String = Nothing
        Private _EMP_LNAME As String = Nothing
        Private _EMP_FML_NAME As String = Nothing
        Private _EMP_FML_NAME_GROUP As String = Nothing
        Private _CL_CODE As String = Nothing
        Private _DIV_CODE As String = Nothing
        Private _PRD_CODE As String = Nothing
        Private _JOB_NUMBER As Nullable(Of Integer) = Nothing
        Private _JOB_COMPONENT_NBR As Nullable(Of Short) = Nothing
        Private _CL_NAME As String = Nothing
        Private _DIV_NAME As String = Nothing
        Private _PRD_DESCRIPTION As String = Nothing
        Private _JOB_DESC As String = Nothing
        Private _JOB_COMP_DESC As String = Nothing
        Private _TASK_NON_TASK_DISPLAY As String = Nothing
        Private _TASK_NON_TASK_DESCRIPTION As String = Nothing
        Private _TASK_STATUS As String = Nothing
        Private _TASK_SEQ_NBR As Nullable(Of Integer) = Nothing
        Private _FNC_CODE As String = Nothing
        Private _TASK_DESCRIPTION As String = Nothing
        Private _TASK_HOURS_ALLOWED As Nullable(Of Decimal) = Nothing
        Private _TRF_CODE As String = Nothing
        Private _TRF_DESCRIPTION As String = Nothing
        Private _THIS_DAY As Nullable(Of Integer) = Nothing
        Private _START_DAY As Nullable(Of Integer) = Nothing
        Private _END_DAY As Nullable(Of Integer) = Nothing
        Private _ALL_DAY As Nullable(Of Integer) = Nothing
        Private _NUM_DAYS As Nullable(Of Integer) = Nothing
        Private _TASK_TEMP_COMPLETE_DATE As Nullable(Of Date) = Nothing
        Private _START_DATE As Nullable(Of Date) = Nothing
        Private _END_DATE As Nullable(Of Date) = Nothing
        Private _START_TIME As Nullable(Of Date) = Nothing
        Private _END_TIME As Nullable(Of Date) = Nothing
        Private _WEEK_VIEW_END_TIME As Nullable(Of Date) = Nothing
        Private _HAS_TIME As Nullable(Of Short) = Nothing
        Private _NON_TASK_ID As Nullable(Of Integer) = Nothing
        Private _NON_TASK_TYPE As String = Nothing
        Private _NON_TASK_HOURS As Nullable(Of Decimal) = Nothing
        Private _NON_TASK_CATEGORY As String = Nothing
        Private _IS_NON_TASK As Nullable(Of Short) = Nothing
        Private _WEEK_VIEW_ALL_DAY As Nullable(Of Boolean) = Nothing
        Private _REC_TYPE As String = Nothing
        Private _REC_ORDER As Nullable(Of Short) = Nothing
        Private _ICAL_ID As String = Nothing
        Private _AD_NBR As String = Nothing
        Private _AD_NBR_DESC As String = Nothing
        Private _AD_NBR_COLOR As String = Nothing
        Private _RESOURCE_CODE As String = Nothing
        Private _RESOURCE_DESC As String = Nothing
        Private _PRIORITY As String = Nothing
        Private _HoursAllowed As String = Nothing
        Private _DUE_TIME As String = Nothing
        Private _EMP_DESC_HRS As String = Nothing
        Private _REMINDER As String = Nothing
        Private _RECURRENCE As String = Nothing
        Private _RECURRENCE_PARENT As Nullable(Of Integer) = Nothing
        Private _RESOURCE_TYPE As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMP_CODE() As String
            Get
                EMP_CODE = _EMP_CODE
            End Get
            Set(value As String)
                _EMP_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMP_FNAME() As String
            Get
                EMP_FNAME = _EMP_FNAME
            End Get
            Set(value As String)
                _EMP_FNAME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMP_MI() As String
            Get
                EMP_MI = _EMP_MI
            End Get
            Set(value As String)
                _EMP_MI = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMP_LNAME() As String
            Get
                EMP_LNAME = _EMP_LNAME
            End Get
            Set(value As String)
                _EMP_LNAME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMP_FML_NAME() As String
            Get
                EMP_FML_NAME = _EMP_FML_NAME
            End Get
            Set(value As String)
                _EMP_FML_NAME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMP_FML_NAME_GROUP() As String
            Get
                EMP_FML_NAME_GROUP = _EMP_FML_NAME_GROUP
            End Get
            Set
                _EMP_FML_NAME_GROUP = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CL_CODE() As String
            Get
                CL_CODE = _CL_CODE
            End Get
            Set(value As String)
                _CL_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DIV_CODE() As String
            Get
                DIV_CODE = _DIV_CODE
            End Get
            Set(value As String)
                _DIV_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PRD_CODE() As String
            Get
                PRD_CODE = _PRD_CODE
            End Get
            Set(value As String)
                _PRD_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JOB_NUMBER() As Nullable(Of Integer)
            Get
                JOB_NUMBER = _JOB_NUMBER
            End Get
            Set(value As Nullable(Of Integer))
                _JOB_NUMBER = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JOB_COMPONENT_NBR() As Nullable(Of Short)
            Get
                JOB_COMPONENT_NBR = _JOB_COMPONENT_NBR
            End Get
            Set(value As Nullable(Of Short))
                _JOB_COMPONENT_NBR = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CL_NAME() As String
            Get
                CL_NAME = _CL_NAME
            End Get
            Set(value As String)
                _CL_NAME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DIV_NAME() As String
            Get
                DIV_NAME = _DIV_NAME
            End Get
            Set(value As String)
                _DIV_NAME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PRD_DESCRIPTION() As String
            Get
                PRD_DESCRIPTION = _PRD_DESCRIPTION
            End Get
            Set(value As String)
                _PRD_DESCRIPTION = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JOB_DESC() As String
            Get
                JOB_DESC = _JOB_DESC
            End Get
            Set(value As String)
                _JOB_DESC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JOB_COMP_DESC() As String
            Get
                JOB_COMP_DESC = _JOB_COMP_DESC
            End Get
            Set(value As String)
                _JOB_COMP_DESC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TASK_NON_TASK_DISPLAY() As String
            Get
                TASK_NON_TASK_DISPLAY = _TASK_NON_TASK_DISPLAY
            End Get
            Set(value As String)
                _TASK_NON_TASK_DISPLAY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TASK_NON_TASK_DESCRIPTION() As String
            Get
                TASK_NON_TASK_DESCRIPTION = _TASK_NON_TASK_DESCRIPTION
            End Get
            Set(value As String)
                _TASK_NON_TASK_DESCRIPTION = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TASK_STATUS() As String
            Get
                TASK_STATUS = _TASK_STATUS
            End Get
            Set(value As String)
                _TASK_STATUS = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TASK_SEQ_NBR() As Nullable(Of Integer)
            Get
                TASK_SEQ_NBR = _TASK_SEQ_NBR
            End Get
            Set(value As Nullable(Of Integer))
                _TASK_SEQ_NBR = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FNC_CODE() As String
            Get
                FNC_CODE = _FNC_CODE
            End Get
            Set(value As String)
                _FNC_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TASK_DESCRIPTION() As String
            Get
                TASK_DESCRIPTION = _TASK_DESCRIPTION
            End Get
            Set(value As String)
                _TASK_DESCRIPTION = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TASK_HOURS_ALLOWED() As Nullable(Of Decimal)
            Get
                TASK_HOURS_ALLOWED = _TASK_HOURS_ALLOWED
            End Get
            Set(value As Nullable(Of Decimal))
                _TASK_HOURS_ALLOWED = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TRF_CODE() As String
            Get
                TRF_CODE = _TRF_CODE
            End Get
            Set(value As String)
                _TRF_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TRF_DESCRIPTION() As String
            Get
                TRF_DESCRIPTION = _TRF_DESCRIPTION
            End Get
            Set(value As String)
                _TRF_DESCRIPTION = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property THIS_DAY() As Nullable(Of Integer)
            Get
                THIS_DAY = _THIS_DAY
            End Get
            Set(value As Nullable(Of Integer))
                _THIS_DAY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property START_DAY() As Nullable(Of Integer)
            Get
                START_DAY = _START_DAY
            End Get
            Set(value As Nullable(Of Integer))
                _START_DAY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property END_DAY() As Nullable(Of Integer)
            Get
                END_DAY = _END_DAY
            End Get
            Set(value As Nullable(Of Integer))
                _END_DAY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ALL_DAY() As Nullable(Of Integer)
            Get
                ALL_DAY = _ALL_DAY
            End Get
            Set(value As Nullable(Of Integer))
                _ALL_DAY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NUM_DAYS() As Nullable(Of Integer)
            Get
                NUM_DAYS = _NUM_DAYS
            End Get
            Set(value As Nullable(Of Integer))
                _NUM_DAYS = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TASK_TEMP_COMPLETE_DATE() As Nullable(Of Date)
            Get
                TASK_TEMP_COMPLETE_DATE = _TASK_TEMP_COMPLETE_DATE
            End Get
            Set(value As Nullable(Of Date))
                _TASK_TEMP_COMPLETE_DATE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property START_DATE() As Nullable(Of Date)
            Get
                START_DATE = _START_DATE
            End Get
            Set(value As Nullable(Of Date))
                _START_DATE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property END_DATE() As Nullable(Of Date)
            Get
                END_DATE = _END_DATE
            End Get
            Set(value As Nullable(Of Date))
                _END_DATE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property START_TIME() As Nullable(Of Date)
            Get
                START_TIME = _START_TIME
            End Get
            Set(value As Nullable(Of Date))
                _START_TIME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property END_TIME() As Nullable(Of Date)
            Get
                END_TIME = _END_TIME
            End Get
            Set(value As Nullable(Of Date))
                _END_TIME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WEEK_VIEW_END_TIME() As Nullable(Of Date)
            Get
                WEEK_VIEW_END_TIME = _WEEK_VIEW_END_TIME
            End Get
            Set(value As Nullable(Of Date))
                _WEEK_VIEW_END_TIME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HAS_TIME() As Nullable(Of Short)
            Get
                HAS_TIME = _HAS_TIME
            End Get
            Set(value As Nullable(Of Short))
                _HAS_TIME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NON_TASK_ID() As Nullable(Of Integer)
            Get
                NON_TASK_ID = _NON_TASK_ID
            End Get
            Set(value As Nullable(Of Integer))
                _NON_TASK_ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NON_TASK_TYPE() As String
            Get
                NON_TASK_TYPE = _NON_TASK_TYPE
            End Get
            Set(value As String)
                _NON_TASK_TYPE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NON_TASK_HOURS() As Nullable(Of Decimal)
            Get
                NON_TASK_HOURS = _NON_TASK_HOURS
            End Get
            Set(value As Nullable(Of Decimal))
                _NON_TASK_HOURS = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NON_TASK_CATEGORY() As String
            Get
                NON_TASK_CATEGORY = _NON_TASK_CATEGORY
            End Get
            Set(value As String)
                _NON_TASK_CATEGORY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IS_NON_TASK() As Nullable(Of Short)
            Get
                IS_NON_TASK = _IS_NON_TASK
            End Get
            Set(value As Nullable(Of Short))
                _IS_NON_TASK = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WEEK_VIEW_ALL_DAY() As Nullable(Of Boolean)
            Get
                WEEK_VIEW_ALL_DAY = _WEEK_VIEW_ALL_DAY
            End Get
            Set(value As Nullable(Of Boolean))
                _WEEK_VIEW_ALL_DAY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property REC_TYPE() As String
            Get
                REC_TYPE = _REC_TYPE
            End Get
            Set(value As String)
                _REC_TYPE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property REC_ORDER() As Nullable(Of Short)
            Get
                REC_ORDER = _REC_ORDER
            End Get
            Set(value As Nullable(Of Short))
                _REC_ORDER = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ICAL_ID() As String
            Get
                ICAL_ID = _ICAL_ID
            End Get
            Set(value As String)
                _ICAL_ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AD_NBR() As String
            Get
                AD_NBR = _AD_NBR
            End Get
            Set(value As String)
                _AD_NBR = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AD_NBR_DESC() As String
            Get
                AD_NBR_DESC = _AD_NBR_DESC
            End Get
            Set(value As String)
                _AD_NBR_DESC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AD_NBR_COLOR() As String
            Get
                AD_NBR_COLOR = _AD_NBR_COLOR
            End Get
            Set(value As String)
                _AD_NBR_COLOR = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RESOURCE_CODE() As String
            Get
                RESOURCE_CODE = _RESOURCE_CODE
            End Get
            Set(value As String)
                _RESOURCE_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RESOURCE_DESC() As String
            Get
                RESOURCE_DESC = _RESOURCE_DESC
            End Get
            Set(value As String)
                _RESOURCE_DESC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PRIORITY() As String
            Get
                PRIORITY = _PRIORITY
            End Get
            Set(value As String)
                _PRIORITY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HoursAllowed() As String
            Get
                HoursAllowed = _HoursAllowed
            End Get
            Set(value As String)
                _HoursAllowed = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DUE_TIME() As String
            Get
                DUE_TIME = _DUE_TIME
            End Get
            Set(value As String)
                _DUE_TIME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMP_DESC_HRS() As String
            Get
                EMP_DESC_HRS = _EMP_DESC_HRS
            End Get
            Set(value As String)
                _EMP_DESC_HRS = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property REMINDER() As String
            Get
                REMINDER = _REMINDER
            End Get
            Set(value As String)
                _REMINDER = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property RECURRENCE() As String
            Get
                RECURRENCE = _RECURRENCE
            End Get
            Set(value As String)
                _RECURRENCE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property RECURRENCE_PARENT() As Nullable(Of Integer)
            Get
                RECURRENCE_PARENT = _RECURRENCE_PARENT
            End Get
            Set(value As Nullable(Of Integer))
                _RECURRENCE_PARENT = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
System.Runtime.Serialization.DataMemberAttribute()>
  Public Property RESOURCE_TYPE() As String
            Get
                RESOURCE_TYPE = _RESOURCE_TYPE
            End Get
            Set(value As String)
                _RESOURCE_TYPE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
