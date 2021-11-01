Namespace EmployeeTimesheet.Classes

    Public Class TimesheetEntry
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            ProductCategoryCode
            ProductCategoryDescription
            JobNumber
            JobDescription
            JobCompNumber
            JobCompDescription
            FunctionCode
            FunctionDescription
            DepartmentTeamCode
            DepartmentTeamDescription
            Progress
            HoursRemaining
            Day1Hours
            Day1Comments
            Day1Key
            Day2Hours
            Day2Comments
            Day2Key
            Day3Hours
            Day3Comments
            Day3Key
            Day4Hours
            Day4Comments
            Day4Key
            Day5Hours
            Day5Comments
            Day5Key
            Day6Hours
            Day6Comments
            Day6Key
            Day7Hours
            Day7Comments
            Day7Key
            IsIndirectTime
            GridGroupByColumn
            QuotedHours
            ActualActualHours
            ProgressIsShowingTrafficHours
            CommentsRequired
            EstimateHours
            EstimateHoursAll
            ScheduleHours
            ScheduleHoursAll
            EstimateVariance
            EstimateVarianceAll
            ScheduleVariance
            ScheduleVarianceAll
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _ProductCategoryCode As String = Nothing
        Private _ProductCategoryDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobCompNumber As Nullable(Of Short) = Nothing
        Private _JobCompDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeamDescription As String = Nothing
        Private _Progress As Nullable(Of Integer) = Nothing
        Private _HoursRemaining As String = Nothing
        Private _Day1Hours As Nullable(Of Decimal) = Nothing
        Private _Day2Hours As Nullable(Of Decimal) = Nothing
        Private _Day3Hours As Nullable(Of Decimal) = Nothing
        Private _Day4Hours As Nullable(Of Decimal) = Nothing
        Private _Day5Hours As Nullable(Of Decimal) = Nothing
        Private _Day6Hours As Nullable(Of Decimal) = Nothing
        Private _Day7Hours As Nullable(Of Decimal) = Nothing
        Private _Day1Key As String = Nothing
        Private _Day2Key As String = Nothing
        Private _Day3Key As String = Nothing
        Private _Day4Key As String = Nothing
        Private _Day5Key As String = Nothing
        Private _Day6Key As String = Nothing
        Private _Day7Key As String = Nothing
        Private _Day1Comments As String = Nothing
        Private _Day2Comments As String = Nothing
        Private _Day3Comments As String = Nothing
        Private _Day4Comments As String = Nothing
        Private _Day5Comments As String = Nothing
        Private _Day6Comments As String = Nothing
        Private _Day7Comments As String = Nothing
        Private _IsNewRecord As Boolean = False
        Private _GridGroupByColumn As String = Nothing
        Private _StartDate As Date = Nothing
        Private _QuotedHours As Nullable(Of Decimal) = Nothing
        Private _ActualHours As Nullable(Of Decimal) = Nothing
        Private _IsOverThreshold As Nullable(Of Boolean) = False
        Private _ProgressIsShowingTrafficHours As Nullable(Of Boolean) = False
        Private _CommentsRequired As Boolean = False
        Private _EstimateHours As Nullable(Of Decimal) = Nothing
        Private _EstimateHoursAll As Nullable(Of Decimal) = Nothing
        Private _ScheduleHours As Nullable(Of Decimal) = Nothing
        Private _ScheduleHoursAll As Nullable(Of Decimal) = Nothing
        Private _EstimateVariance As Nullable(Of Decimal) = Nothing
        Private _EstimateVarianceAll As Nullable(Of Decimal) = Nothing
        Private _ScheduleVariance As Nullable(Of Decimal) = Nothing
        Private _ScheduleVarianceAll As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DivisionName)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ProductName)>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Category", PropertyType:=BaseClasses.PropertyTypes.ProductCategory)>
        Public Property ProductCategoryCode() As String
            Get
                ProductCategoryCode = _ProductCategoryCode
            End Get
            Set(value As String)
                _ProductCategoryCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ProductCategoryDescription)>
        Public Property ProductCategoryDescription() As String
            Get
                ProductCategoryDescription = _ProductCategoryDescription
            End Get
            Set(value As String)
                _ProductCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobDescription)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobCompNumber() As Nullable(Of Short)
            Get
                JobCompNumber = _JobCompNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobCompNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobComponentDescription)>
        Public Property JobCompDescription() As String
            Get
                JobCompDescription = _JobCompDescription
            End Get
            Set(value As String)
                _JobCompDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Func / Cat", PropertyType:=BaseClasses.PropertyTypes.EmployeeFunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.FunctionDescription)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DepartmentTeamName)>
        Public Property DepartmentTeamDescription() As String
            Get
                DepartmentTeamDescription = _DepartmentTeamDescription
            End Get
            Set(value As String)
                _DepartmentTeamDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Progress() As Nullable(Of Integer)
            Get

                If Me.QuotedHours.GetValueOrDefault(0) > 0 Then

                    Progress = (Me.ActualHours.GetValueOrDefault(0) / Me.QuotedHours.GetValueOrDefault(0)) * 100

                Else

                    Progress = 100

                End If

            End Get
            Set(value As Nullable(Of Integer))

            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property HoursRemaining() As Nullable(Of Decimal)
            Get
                HoursRemaining = Me.QuotedHours.GetValueOrDefault(0) - Me.ActualHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))

            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
        Public Property Day1Hours() As Nullable(Of Decimal)
            Get
                Day1Hours = _Day1Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day1Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Day1Comments() As String
            Get
                Day1Comments = _Day1Comments
            End Get
            Set(value As String)
                _Day1Comments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
        Public Property Day2Hours() As Nullable(Of Decimal)
            Get
                Day2Hours = _Day2Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day2Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Day2Comments() As String
            Get
                Day2Comments = _Day2Comments
            End Get
            Set(value As String)
                _Day2Comments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
        Public Property Day3Hours() As Nullable(Of Decimal)
            Get
                Day3Hours = _Day3Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day3Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Day3Comments() As String
            Get
                Day3Comments = _Day3Comments
            End Get
            Set(value As String)
                _Day3Comments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
        Public Property Day4Hours() As Nullable(Of Decimal)
            Get
                Day4Hours = _Day4Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day4Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Day4Comments() As String
            Get
                Day4Comments = _Day4Comments
            End Get
            Set(value As String)
                _Day4Comments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
        Public Property Day5Hours() As Nullable(Of Decimal)
            Get
                Day5Hours = _Day5Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day5Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Day5Comments() As String
            Get
                Day5Comments = _Day5Comments
            End Get
            Set(value As String)
                _Day5Comments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
        Public Property Day6Hours() As Nullable(Of Decimal)
            Get
                Day6Hours = _Day6Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day6Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Day6Comments() As String
            Get
                Day6Comments = _Day6Comments
            End Get
            Set(value As String)
                _Day6Comments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
        Public Property Day7Hours() As Nullable(Of Decimal)
            Get
                Day7Hours = _Day7Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day7Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Day7Comments() As String
            Get
                Day7Comments = _Day7Comments
            End Get
            Set(value As String)
                _Day7Comments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Day1Key() As String
            Get
                Day1Key = _Day1Key
            End Get
            Set(value As String)
                _Day1Key = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Day2Key() As String
            Get
                Day2Key = _Day2Key
            End Get
            Set(value As String)
                _Day2Key = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Day3Key() As String
            Get
                Day3Key = _Day3Key
            End Get
            Set(value As String)
                _Day3Key = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Day4Key() As String
            Get
                Day4Key = _Day4Key
            End Get
            Set(value As String)
                _Day4Key = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Day5Key() As String
            Get
                Day5Key = _Day5Key
            End Get
            Set(value As String)
                _Day5Key = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Day6Key() As String
            Get
                Day6Key = _Day6Key
            End Get
            Set(value As String)
                _Day6Key = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Day7Key() As String
            Get
                Day7Key = _Day7Key
            End Get
            Set(value As String)
                _Day7Key = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property IsIndirectTime() As Boolean
            Get

                'objects
                Dim IsIndirect As Boolean = True

                Try

                    If String.IsNullOrEmpty(Me.ClientCode) = False OrElse _
                       String.IsNullOrEmpty(Me.DivisionCode) = False OrElse _
                       String.IsNullOrEmpty(Me.ProductCode) = False OrElse _
                       Me.JobNumber.HasValue OrElse _
                       Me.JobCompNumber.HasValue Then

                        IsIndirect = False

                    End If

                Catch ex As Exception
                    IsIndirect = False
                Finally
                    IsIndirectTime = IsIndirect
                End Try

            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GridGroupByColumn As String
            Get
                GridGroupByColumn = _GridGroupByColumn
            End Get
            Set(value As String)
                _GridGroupByColumn = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property QuotedHours As Nullable(Of Decimal)
            Get
                QuotedHours = _QuotedHours
            End Get
            Set(value As Nullable(Of Decimal))
                _QuotedHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ActualHours As Nullable(Of Decimal)
            Get
                ActualHours = _ActualHours
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsOverThreshold As Nullable(Of Boolean)
            Get
                IsOverThreshold = _IsOverThreshold
            End Get
            Set(value As Nullable(Of Boolean))
                _IsOverThreshold = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ProgressIsShowingTrafficHours As Nullable(Of Boolean)
            Get
                ProgressIsShowingTrafficHours = _ProgressIsShowingTrafficHours
            End Get
            Set(value As Nullable(Of Boolean))
                _ProgressIsShowingTrafficHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CommentsRequired As Boolean
            Get
                CommentsRequired = _CommentsRequired
            End Get
            Set(value As Boolean)
                _CommentsRequired = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EstimateHours As Nullable(Of Decimal)
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EstimateHoursAll As Nullable(Of Decimal)
            Get
                EstimateHoursAll = _EstimateHoursAll
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateHoursAll = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ScheduleHours As Nullable(Of Decimal)
            Get
                ScheduleHours = _ScheduleHours
            End Get
            Set(value As Nullable(Of Decimal))
                _ScheduleHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ScheduleHoursAll As Nullable(Of Decimal)
            Get
                ScheduleHoursAll = _ScheduleHoursAll
            End Get
            Set(value As Nullable(Of Decimal))
                _ScheduleHoursAll = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EstimateVariance As Nullable(Of Decimal)
            Get
                EstimateVariance = _EstimateVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateVariance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EstimateVarianceAll As Nullable(Of Decimal)
            Get
                EstimateVarianceAll = _EstimateVarianceAll
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateVarianceAll = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ScheduleVariance As Nullable(Of Decimal)
            Get
                ScheduleVariance = _ScheduleVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _ScheduleVariance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ScheduleVarianceAll As Nullable(Of Decimal)
            Get
                ScheduleVarianceAll = _ScheduleVarianceAll
            End Get
            Set(value As Nullable(Of Decimal))
                _ScheduleVarianceAll = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property QvAStatusMessage As String
            Get

                'objects
                Dim Message As String = Nothing
                Dim HoursRemaining As Decimal = Nothing

                If Me.QuotedHours.GetValueOrDefault(0) > 0 Then

                    HoursRemaining = Me.QuotedHours.GetValueOrDefault(0) - Me.ActualHours.GetValueOrDefault(0)

                    Message = FormatNumber(Me.ActualHours.GetValueOrDefault(0), 2) & " posted hours of " & FormatNumber(Me.QuotedHours.GetValueOrDefault(0), 2) & " " & If(Me.ProgressIsShowingTrafficHours.GetValueOrDefault(False) = True, "traffic", "quoted") & " hours"

                    If HoursRemaining > 0 Then

                        Message &= ", remaining: " & FormatNumber(HoursRemaining, 2) & " hours"

                    ElseIf HoursRemaining < 0 Then

                        Message &= ", over by: " & FormatNumber(HoursRemaining * -1, 2) & " hours"

                    End If

                Else

                    Message = FormatNumber(Me.ActualHours.GetValueOrDefault(0), 2) & " posted hours"

                End If

                QvAStatusMessage = Message

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _IsNewRecord = True

        End Sub
        Public Sub New(ByVal EmployeeTimeComplex As AdvantageFramework.Database.Classes.EmployeeTimeComplex)

            _ClientCode = EmployeeTimeComplex.ClientCode
            _ClientName = EmployeeTimeComplex.ClientName
            _DivisionCode = EmployeeTimeComplex.DivisionCode
            _DivisionName = EmployeeTimeComplex.DivisionName
            _ProductCode = EmployeeTimeComplex.ProductCode
            _ProductName = EmployeeTimeComplex.ProductDescription
            _JobNumber = EmployeeTimeComplex.JobNumber
            _JobDescription = EmployeeTimeComplex.JobDescription
            _JobCompNumber = EmployeeTimeComplex.JobComponentNumber
            _JobCompDescription = EmployeeTimeComplex.JobComponentDescription
            _FunctionCode = EmployeeTimeComplex.FunctionCategory
            _FunctionDescription = EmployeeTimeComplex.FunctionCategoryDescription
            _DepartmentTeamCode = EmployeeTimeComplex.DepartmentTeamCode
            _DepartmentTeamDescription = EmployeeTimeComplex.DepartmentTeamCode
            _ProductCategoryCode = EmployeeTimeComplex.ProductCategoryCode
            _ProductCategoryDescription = EmployeeTimeComplex.ProductCategoryDescription

        End Sub
        Public Sub SetHours(ByVal EmployeeTimeComplex As AdvantageFramework.Database.Classes.EmployeeTimeComplex, ByVal PropertyName As String)

            'objects
            Dim DayKey As String = Nothing
            Dim FormatedHours As Nullable(Of Decimal) = Nothing
            Dim HoursPropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim KeyPropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                DayKey = CreateDayKey(EmployeeTimeComplex.EmployeeTimeID, EmployeeTimeComplex.EmployeeTimeDetailID)

                FormatedHours = FormatHours(EmployeeTimeComplex.EmployeeHours)

                HoursPropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = PropertyName).SingleOrDefault

                KeyPropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = PropertyName.Replace("Hours", "Key")).SingleOrDefault

                HoursPropertyDescriptor.SetValue(Me, FormatedHours)
                KeyPropertyDescriptor.SetValue(Me, DayKey)

            Catch ex As Exception

            End Try

        End Sub
        Public Sub SetEntryDayProperties(ByVal EmployeeTimeComplex As AdvantageFramework.Database.Classes.EmployeeTimeComplex, ByVal DayNumber As Integer, ByVal EmployeeComment As String)

            Try

                Select Case DayNumber

                    Case 1

                        SetHours(EmployeeTimeComplex, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString)
                        Me.Day1Comments = EmployeeComment

                    Case 2

                        SetHours(EmployeeTimeComplex, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString)
                        Me.Day2Comments = EmployeeComment

                    Case 3

                        SetHours(EmployeeTimeComplex, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString)
                        Me.Day3Comments = EmployeeComment

                    Case 4

                        SetHours(EmployeeTimeComplex, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString)
                        Me.Day4Comments = EmployeeComment

                    Case 5

                        SetHours(EmployeeTimeComplex, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString)
                        Me.Day5Comments = EmployeeComment

                    Case 6

                        SetHours(EmployeeTimeComplex, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString)
                        Me.Day6Comments = EmployeeComment

                    Case 7

                        SetHours(EmployeeTimeComplex, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString)
                        Me.Day7Comments = EmployeeComment

                End Select

            Catch ex As Exception

            End Try

        End Sub
        Public Function CreateDayKey(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As String

            'objects
            Dim DayKey As String = Nothing

            Try

                DayKey = EmployeeTimeID.ToString & "|" & EmployeeTimeDetailID.ToString

            Catch ex As Exception
                DayKey = ""
            Finally
                CreateDayKey = DayKey
            End Try

        End Function
        Public Sub SetDataKey(ByVal Day As Integer, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = "Day" & Day.ToString & "Key").SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                PropertyDescriptor.SetValue(Me, CreateDayKey(EmployeeTimeID, EmployeeTimeDetailID))

            End If

        End Sub
        Public Sub SetIsNewRecord(ByVal IsNewRecord As Boolean)

            _IsNewRecord = IsNewRecord

        End Sub
        Public Function DoesRecordHaveTime(Optional ByVal DayPropertyToSkip As String = Nothing) As Boolean

            'objects
            Dim HasTime As Boolean = False
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim Hours As Nullable(Of Decimal) = Nothing
            Dim DayNumber As Short = Nothing

            For DayNumber = 1 To 7

                Try

                    PropertyDescriptor = (From Prop In System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)() _
                                          Where Prop.Name <> DayPropertyToSkip AndAlso _
                                                Prop.Name = "Day" & DayNumber.ToString & "Hours" _
                                          Select Prop).SingleOrDefault

                    If PropertyDescriptor IsNot Nothing Then

                        Hours = PropertyDescriptor.GetValue(Me)

                        If Hours.HasValue AndAlso Hours.Value > 0 Then

                            HasTime = True
                            Exit For

                        End If

                    End If

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

            Next

            DoesRecordHaveTime = HasTime

        End Function
        Private Function FormatHours(ByVal Hours As Decimal) As Object

            Try

                FormatHours = Math.Round(Hours, 2, MidpointRounding.AwayFromZero)

            Catch ex As Exception
                FormatHours = Nothing
            End Try

        End Function
        Private Sub ParseDataKey(ByVal DataKey As String, ByRef EmployeeTimeID As Integer, ByRef EmployeeTimeDetailID As Integer)

            'objects
            Dim DataKeyArray As String() = Nothing

            Try

                If String.IsNullOrEmpty(DataKey) = False Then

                    DataKeyArray = DataKey.Split("|")

                    EmployeeTimeID = CInt(DataKeyArray.FirstOrDefault)
                    EmployeeTimeDetailID = CInt(DataKeyArray.Last)

                End If

            Catch ex As Exception
                EmployeeTimeID = 0
                EmployeeTimeDetailID = 0
            End Try

        End Sub
        Public Sub SetStartDate(ByVal StartDate As Date)

            _StartDate = StartDate

        End Sub

#Region "  Validation "

        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim HoursColumn As String = Nothing

            Select Case PropertyName

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString

                    SetRequired(PropertyName, Not Me.IsIndirectTime)

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString

                    Try

                        PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = PropertyName).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        Try

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                        Catch ex As Exception
                            EntityAttribute = Nothing
                        End Try

                        If EntityAttribute IsNot Nothing Then

                            If Me.IsIndirectTime = True Then

                                EntityAttribute.PropertyType = BaseClasses.PropertyTypes.IndirectCategory

                            Else

                                EntityAttribute.PropertyType = BaseClasses.PropertyTypes.FunctionCode

                            End If

                        End If

                    End If

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString

                    If _IsNewRecord AndAlso Value Is Nothing Then

                        SetRequired(PropertyName, Not DoesRecordHaveTime(PropertyName))

                    Else

                        SetRequired(PropertyName, False)

                    End If

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString

                    SetRequired(PropertyName, TimeCommentsRequired(Me.DbContext, PropertyName))

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString

                    If _IsNewRecord Then

                        SetRequired(PropertyName, ProductCategoryRequired())

                    End If

            End Select

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String, IsEntityKey As Boolean, IsNullable As Boolean, IsRequired As Boolean, MaxLength As Integer, Precision As Long, Scale As Long, PropertyType As BaseClasses.PropertyTypes)

            'objects
            Dim Day As Integer = Nothing

            Select Case PropertyName

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString

                    If _IsNewRecord = True AndAlso Value Is Nothing Then

                        If DoesRecordHaveTime(PropertyName) = False Then

                            ErrorText = "Please enter hours for at least 1 day."
                            IsValid = False

                        End If

                    End If

                    If ErrorText.Contains(AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName)) = True Then

                        Day = CInt(PropertyName.Replace("Day", "").Replace("Hours", ""))

                        ErrorText = ErrorText.Replace(AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName), _StartDate.AddDays(Day - 1).ToShortDateString & " hours")

                    End If

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString

                    If ErrorText.Contains(AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName)) = True Then

                        Day = CInt(PropertyName.Replace("Day", "").Replace("Comments", ""))

                        ErrorText = ErrorText.Replace(AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName), _StartDate.AddDays(Day - 1).ToShortDateString & " Comment")

                    End If

            End Select

        End Sub
        Protected Function TimeCommentsRequired(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CommentField As String) As Boolean

            'objects
            Dim IsRequired As Boolean = False
            Dim HasHours As Boolean = False
            Dim DataKey As String = Nothing
            Dim EmployeeTimeID As Integer = Nothing
            Dim EmployeeTimeDetailID As Integer = Nothing

            Select Case CommentField

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString

                    HasHours = Me.Day1Hours.HasValue
                    DataKey = Me.Day1Key

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString

                    HasHours = Me.Day2Hours.HasValue
                    DataKey = Me.Day2Key

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString

                    HasHours = Me.Day3Hours.HasValue
                    DataKey = Me.Day3Key

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString

                    HasHours = Me.Day4Hours.HasValue
                    DataKey = Me.Day4Key

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString

                    HasHours = Me.Day5Hours.HasValue
                    DataKey = Me.Day5Key

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString

                    HasHours = Me.Day6Hours.HasValue
                    DataKey = Me.Day6Key

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString

                    HasHours = Me.Day7Hours.HasValue
                    DataKey = Me.Day7Key

            End Select

            If HasHours Then

                ParseDataKey(DataKey, EmployeeTimeID, EmployeeTimeDetailID)

                IsRequired = AdvantageFramework.EmployeeTimesheet.CheckTimeCommentsRequired(DbContext, Me.JobNumber.GetValueOrDefault(0), EmployeeTimeID, EmployeeTimeID)

            End If

            TimeCommentsRequired = IsRequired

        End Function
        Protected Function ProductCategoryRequired() As Boolean

            'objects
            Dim IsRequired As Boolean = False
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            Try

                If _DbContext IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.Agency.Load(_DbContext).EnableProductCategory.GetValueOrDefault(0) = 1 Then

                        If String.IsNullOrEmpty(Me.ClientCode) = False Then

                            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(_DbContext, Me.ClientCode)

                            If Client IsNot Nothing Then

                                IsRequired = CBool(Client.ProductCategoryInTimesheetRequired.GetValueOrDefault(0))

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                IsRequired = False
            Finally
                ProductCategoryRequired = IsRequired
            End Try

        End Function

#End Region

#End Region

    End Class

End Namespace


