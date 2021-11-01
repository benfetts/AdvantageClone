Namespace Database.Entities

    <System.Data.Linq.Mapping.Table(Name:="dbo.EMP_NON_TASKS")> _
    Public Class EmployeeNonTask

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Type
            StartDate
            EndDate
            IsAllDay
            Description
            StartDateAndTime
            EndDateAndTime
            Hours
            EmployeeCode
            Category
            FunctionCode
            JobNumber
            JobComponentNumber
            GoogleID
            ClientCode
            DivisionCode
            ProductCode
            Priority
            Reminder
            Recurrence
            TaskCode
            NontaskDescription
            RecurrenceParent
            ContactID
            SugarCRMID
            NonTaskHTML
            OutlookID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _Type As String = Nothing
        Private _StartDate As System.Nullable(Of DateTime) = Nothing
        Private _EndDate As System.Nullable(Of DateTime) = Nothing
        Private _IsAllDay As System.Nullable(Of Long) = Nothing
        Private _Description As String = Nothing
        Private _StartDateAndTime As System.Nullable(Of DateTime) = Nothing
        Private _EndDateAndTime As System.Nullable(Of DateTime) = Nothing
        Private _Hours As System.Nullable(Of Decimal) = 0
        Private _EmployeeCode As String = Nothing
        Private _Category As String = Nothing
        Private _FunctionCode As System.Nullable(Of Long) = Nothing
        Private _JobNumber As System.Nullable(Of Long) = Nothing
        Private _JobComponentNumber As String = Nothing
        Private _GoogleID As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Priority As System.Nullable(Of Long) = Nothing
        Private _Reminder As String = Nothing
        Private _Recurrence As String = Nothing
        Private _TaskCode As System.Nullable(Of Long) = Nothing
        Private _NontaskDescription As String = Nothing
        Private _RecurrenceParent As String = Nothing
        Private _ContactID As System.Nullable(Of Long) = Nothing
        Private _SugarCRMID As String = Nothing
        Private _NonTaskHTML As String = Nothing
        Private _OutlookID As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NON_TASK_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TYPE", Storage:="_Type", DBType:="varchar")> _
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="START_DATE", Storage:="_StartDate", DBType:="smalldatetime")> _
        Public Property StartDate() As System.Nullable(Of DateTime)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _StartDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="END_DATE", Storage:="_EndDate", DBType:="smalldatetime")> _
        Public Property EndDate() As System.Nullable(Of DateTime)
            Get
                EndDate = _EndDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _EndDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ALL_DAY", Storage:="_IsAllDay", DBType:="int")> _
        Public Property IsAllDay() As System.Nullable(Of Long)
            Get
                IsAllDay = _IsAllDay
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsAllDay = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NON_TASK_DESC", Storage:="_Description", DBType:="varchar")> _
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="START_TIME", Storage:="_StartDateAndTime", DBType:="datetime")> _
        Public Property StartDateAndTime() As System.Nullable(Of DateTime)
            Get
                StartDateAndTime = _StartDateAndTime
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _StartDateAndTime = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="END_TIME", Storage:="_EndDateAndTime", DBType:="datetime")> _
        Public Property EndDateAndTime() As System.Nullable(Of DateTime)
            Get
                EndDateAndTime = _EndDateAndTime
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _EndDateAndTime = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HOURS", Storage:="_Hours", DBType:="decimal")> _
        Public Property Hours() As System.Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_CODE", Storage:="_EmployeeCode", DBType:="varchar")> _
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CATEGORY", Storage:="_Category", DBType:="varchar")> _
        Public Property Category() As String
            Get
                Category = _Category
            End Get
            Set(ByVal value As String)
                _Category = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_NUMBER", Storage:="_FunctionCode", DBType:="int")> _
        Public Property FunctionCode() As System.Nullable(Of Long)
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _FunctionCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_COMPONENT_NBR", Storage:="_JobNumber", DBType:="smallint")> _
        Public Property JobNumber() As System.Nullable(Of Long)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _JobNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_CODE", Storage:="_JobComponentNumber", DBType:="varchar")> _
        Public Property JobComponentNumber() As String
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As String)
                _JobComponentNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GOOGLE_ID", Storage:="_GoogleID", DBType:="varchar")> _
        Public Property GoogleID() As String
            Get
                GoogleID = _GoogleID
            End Get
            Set(ByVal value As String)
                _GoogleID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_CODE", Storage:="_ClientCode", DBType:="varchar")> _
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DIV_CODE", Storage:="_DivisionCode", DBType:="varchar")> _
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRD_CODE", Storage:="_ProductCode", DBType:="varchar")> _
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRIORITY", Storage:="_Priority", DBType:="smallint")> _
        Public Property Priority() As System.Nullable(Of Long)
            Get
                Priority = _Priority
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _Priority = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REMINDER", Storage:="_Reminder", DBType:="nvarchar")> _
        Public Property Reminder() As String
            Get
                Reminder = _Reminder
            End Get
            Set(ByVal value As String)
                _Reminder = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RECURRENCE", Storage:="_Recurrence", DBType:="nvarchar")> _
        Public Property Recurrence() As String
            Get
                Recurrence = _Recurrence
            End Get
            Set(ByVal value As String)
                _Recurrence = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RECURRENCE_PARENT", Storage:="_TaskCode", DBType:="int")> _
        Public Property TaskCode() As System.Nullable(Of Long)
            Get
                TaskCode = _TaskCode
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _TaskCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TASK_CODE", Storage:="_NontaskDescription", DBType:="varchar")> _
        Public Property NontaskDescription() As String
            Get
                NontaskDescription = _NontaskDescription
            End Get
            Set(ByVal value As String)
                _NontaskDescription = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NON_EMP_TASK_DESC", Storage:="_RecurrenceParent", DBType:="text"), _
        System.ComponentModel.DisplayName("RecurrenceParent")> _
        Public Property RecurrenceParent() As String
            Get
                RecurrenceParent = _RecurrenceParent
            End Get
            Set(ByVal value As String)
                _RecurrenceParent = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CDP_CONTACT_ID", Storage:="_ContactID", DBType:="int")> _
        Public Property ContactID() As System.Nullable(Of Long)
            Get
                ContactID = _ContactID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _ContactID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUGARCRM_ID", Storage:="_SugarCRMID", DBType:="varchar")> _
        Public Property SugarCRMID() As String
            Get
                SugarCRMID = _SugarCRMID
            End Get
            Set(ByVal value As String)
                _SugarCRMID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NON_EMP_TASK_HTML", Storage:="_NonTaskHTML", DBType:="varchar")> _
        Public Property NonTaskHTML() As String
            Get
                NonTaskHTML = _NonTaskHTML
            End Get
            Set(ByVal value As String)
                _NonTaskHTML = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OUTLOOK_ID", Storage:="_OutlookID", DBType:="varchar")> _
        Public Property OutlookID() As String
            Get
                OutlookID = _OutlookID
            End Get
            Set(ByVal value As String)
                _OutlookID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
