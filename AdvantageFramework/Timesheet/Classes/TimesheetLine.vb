Namespace Timesheet

    <Serializable()> Public Class TimesheetLine

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BaseLineIdentifier As String = ""
        Private _LineIdentifier As String = ""
        Private _Client As String = ""
        Private _Division As String = ""
        Private _Product As String = ""
        Private _Job As Integer = 0
        Private _JobDesc As String = ""
        Private _JobComp As Integer = 0
        Private _JobCompDesc As String = ""
        Private _FuncCat As String = ""
        Private _FuncCatDesc As String = ""
        Private _Dept As String = ""
        Private _ProductCategory As String = ""
        Private _TotalHours As Double = 0
        Private _Monday As TimesheetEntry = Nothing 'New TimesheetEntry
        Private _Tuesday As TimesheetEntry = Nothing 'New TimesheetEntry
        Private _Wednesday As TimesheetEntry = Nothing 'New TimesheetEntry
        Private _Thursday As TimesheetEntry = Nothing 'New TimesheetEntry
        Private _Friday As TimesheetEntry = Nothing 'New TimesheetEntry
        Private _Saturday As TimesheetEntry = Nothing 'New TimesheetEntry
        Private _Sunday As TimesheetEntry = Nothing 'New TimesheetEntry
        Private _CL_NAME As String = ""
        Private _DIV_NAME As String = ""
        Private _PRD_NAME As String = ""
        Private _Proc_control As Integer = 0
        Private _NonEditMessage As String = ""
        Private _TimeType As String = ""
        Private _AlertID As Integer = 0
        Private _AlertSubject As String

#End Region

#Region " Properties "

        Public Property AlertSubject() As String
            Get
                Return _AlertSubject
            End Get
            Set(ByVal Value As String)
                _AlertSubject = Value
            End Set
        End Property

        Public Property AlertID() As Integer
            Get
                Return _AlertID
            End Get
            Set(ByVal value As Integer)
                _AlertID = value
            End Set
        End Property
        Public Property BaseLineIdentifier() As String
            Get
                Return _BaseLineIdentifier
            End Get
            Set(ByVal Value As String)
                _BaseLineIdentifier = Value
            End Set
        End Property
        Public Property LineIdentifier() As String
            Get
                Return _LineIdentifier
            End Get
            Set(ByVal Value As String)
                _LineIdentifier = Value
            End Set
        End Property
        Public Property NonEditMessage() As String
            Get
                Return _NonEditMessage
            End Get
            Set(ByVal value As String)
                _NonEditMessage = value
            End Set
        End Property
        Public Property JobProcessControl() As Integer
            Get
                Return _Proc_control
            End Get
            Set(ByVal value As Integer)
                _Proc_control = value
            End Set
        End Property
        Public Property ClientName() As String
            Get
                Return _CL_NAME
            End Get
            Set(ByVal value As String)
                _CL_NAME = value
            End Set
        End Property
        Public Property DivisionName() As String
            Get
                Return _DIV_NAME
            End Get
            Set(ByVal value As String)
                _DIV_NAME = value
            End Set
        End Property
        Public Property ProductDescription() As String
            Get
                Return _PRD_NAME

            End Get
            Set(ByVal value As String)
                _PRD_NAME = value

            End Set
        End Property
        Public Property ClientCode() As String
            Get
                Return _Client
            End Get
            Set(ByVal Value As String)
                _Client = Value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                Return _Division
            End Get
            Set(ByVal Value As String)
                _Division = Value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                Return _Product
            End Get
            Set(ByVal Value As String)
                _Product = Value
            End Set
        End Property
        Public Property JobNumber() As Integer
            Get
                Return _Job
            End Get
            Set(ByVal Value As Integer)
                _Job = Value
            End Set
        End Property
        Public Property JobDesc() As String
            Get
                Return _JobDesc
            End Get
            Set(ByVal Value As String)
                _JobDesc = Value
            End Set
        End Property
        Public Property JobComponentNbr() As Integer
            Get
                Return _JobComp
            End Get
            Set(ByVal Value As Integer)
                _JobComp = Value
            End Set
        End Property
        Public Property JobCompDesc() As String
            Get
                Return _JobCompDesc
            End Get
            Set(ByVal Value As String)
                _JobCompDesc = Value
            End Set
        End Property
        Public Property FuncCat() As String
            Get
                Return _FuncCat
            End Get
            Set(ByVal Value As String)
                _FuncCat = Value
            End Set
        End Property
        Public Property FuncCatDesc() As String
            Get
                Return _FuncCatDesc
            End Get
            Set(value As String)
                _FuncCatDesc = value
            End Set
        End Property
        Public Property Dept() As String
            Get
                Return _Dept
            End Get
            Set(ByVal Value As String)
                _Dept = Value
            End Set
        End Property
        Public Property ProductCategory() As String
            Get
                Return _ProductCategory
            End Get
            Set(ByVal Value As String)
                _ProductCategory = Value
            End Set
        End Property
        Public Property TimeType() As String
            Get
                Return _TimeType
            End Get
            Set(ByVal Value As String)
                _TimeType = Value
            End Set
        End Property
        Public Property TotalHours() As Double
            Get
                Return _TotalHours
            End Get
            Set(ByVal Value As Double)
                _TotalHours = Value
            End Set
        End Property
        Public Property Monday() As TimesheetEntry
            Get
                Return _Monday
            End Get
            Set(ByVal Value As TimesheetEntry)
                _Monday = Value
            End Set
        End Property
        Public Property Tuesday() As TimesheetEntry
            Get
                Return _Tuesday
            End Get
            Set(ByVal Value As TimesheetEntry)
                _Tuesday = Value
            End Set
        End Property
        Public Property Wednesday() As TimesheetEntry
            Get
                Return _Wednesday
            End Get
            Set(ByVal Value As TimesheetEntry)
                _Wednesday = Value
            End Set
        End Property
        Public Property Thursday() As TimesheetEntry
            Get
                Return _Thursday
            End Get
            Set(ByVal Value As TimesheetEntry)
                _Thursday = Value
            End Set
        End Property
        Public Property Friday() As TimesheetEntry
            Get
                Return _Friday
            End Get
            Set(ByVal Value As TimesheetEntry)
                _Friday = Value
            End Set
        End Property
        Public Property Saturday() As TimesheetEntry
            Get
                Return _Saturday
            End Get
            Set(ByVal Value As TimesheetEntry)
                _Saturday = Value
            End Set
        End Property
        Public Property Sunday() As TimesheetEntry
            Get
                Return _Sunday
            End Get
            Set(ByVal Value As TimesheetEntry)
                _Sunday = Value
            End Set
        End Property
        Public Property QuotedAmount As Double = 0.0
        Public Property QuotedHours As Double = 0.0
        Public Property ActualAmount As Double = 0.0
        Public Property ActualHours As Double = 0.0
        Public Property Threshold As Integer = 0
        Public Property IsOverThreshold As Boolean = False
        Public Property ProgressIsShowingTrafficHours As Boolean = False
        Public Property ProgressIsShowingOnlyEmployee As Boolean = False
        Public Property CannotEditDueToProcessingControl As Boolean = False
        Public Property ClientCommentRequired As Boolean = False

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace