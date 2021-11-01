Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="NotifyTaskData")>
    <Serializable()>
    Public Class NotifyTaskData
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EMPCODE
            CLIENTNAME
            JOBDESC
            COMPONENTDESC
            TASKDESC
            ALERTEMAIL
            COMPONENTNUMBER
            EMAIL
            JOBNUMBER
            DATEDIFF
            COMMENT
            STARTDATE
            DUEDATE
            HOURSALLOWED
            SUPERVISORCODE
        End Enum

#End Region

#Region " Variables "

        Private _EMP_CODE As String = Nothing
        Private _CLIENT_NAME As String = Nothing
        Private _JOB_DESC As String = Nothing
        Private _COMPONENT_DESC As String = Nothing
        Private _TASK_DESC As String = Nothing
        Private _ALERT_EMAIL As Nullable(Of Short) = Nothing
        Private _COMPONENT_NUMBER As Short = Nothing
        Private _EMAIL As String = Nothing
        Private _JOB_NUMBER As Integer = Nothing
        Private _DATE_DIFF As Nullable(Of Integer) = Nothing
        Private _COMMENT As String = Nothing
        Private _START_DATE As Nullable(Of Date) = Nothing
        Private _DUE_DATE As Nullable(Of Date) = Nothing
        Private _HOURS_ALLOWED As Nullable(Of Decimal) = Nothing
        Private _SUPERVISOR_CODE As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMP_CODE() As String
            Get
                EMP_CODE = _EMP_CODE
            End Get
            Set(ByVal value As String)
                _EMP_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CLIENT_NAME() As String
            Get
                CLIENT_NAME = _CLIENT_NAME
            End Get
            Set(ByVal value As String)
                _CLIENT_NAME = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JOB_DESC() As String
            Get
                JOB_DESC = _JOB_DESC
            End Get
            Set(ByVal value As String)
                _JOB_DESC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property COMPONENT_DESC() As String
            Get
                COMPONENT_DESC = _COMPONENT_DESC
            End Get
            Set(ByVal value As String)
                _COMPONENT_DESC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TASK_DESC() As String
            Get
                TASK_DESC = _TASK_DESC
            End Get
            Set(ByVal value As String)
                _TASK_DESC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ALERT_EMAIL() As Nullable(Of Short)
            Get
                ALERT_EMAIL = _ALERT_EMAIL
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ALERT_EMAIL = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property COMPONENT_NUMBER() As Short
            Get
                COMPONENT_NUMBER = _COMPONENT_NUMBER
            End Get
            Set(ByVal value As Short)
                _COMPONENT_NUMBER = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EMAIL() As String
            Get
                EMAIL = _EMAIL
            End Get
            Set(ByVal value As String)
                _EMAIL = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JOB_NUMBER() As Integer
            Get
                JOB_NUMBER = _JOB_NUMBER
            End Get
            Set(ByVal value As Integer)
                _JOB_NUMBER = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DATE_DIFF() As Nullable(Of Integer)
            Get
                DATE_DIFF = _DATE_DIFF
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _DATE_DIFF = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property COMMENT() As String
            Get
                COMMENT = _COMMENT
            End Get
            Set(ByVal value As String)
                _COMMENT = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property START_DATE() As Nullable(Of Date)
            Get
                START_DATE = _START_DATE
            End Get
            Set(ByVal value As Nullable(Of Date))
                _START_DATE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DUE_DATE() As Nullable(Of Date)
            Get
                DUE_DATE = _DUE_DATE
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DUE_DATE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HOURS_ALLOWED() As Nullable(Of Decimal)
            Get
                HOURS_ALLOWED = _HOURS_ALLOWED
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _HOURS_ALLOWED = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
      System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SUPERVISOR_CODE() As String
            Get
                SUPERVISOR_CODE = _SUPERVISOR_CODE
            End Get
            Set(ByVal value As String)
                _SUPERVISOR_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EMP_CODE.ToString

        End Function

#End Region

    End Class

End Namespace
