Namespace Database.Classes

    <Serializable()>
    Public Class NonbilledEmployeeTimeComplex

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeID
            EmployeeTimeDetailID
            SequenceNumber
            EmployeeCode
            EmployeeName
            EmployeeDate
            DepartmentTeamCode
            DepartmentTeamDescription
            EmployeeTitleID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            FunctionDescription
            EmployeeHours
            EmployeeNonBillableFlag
            FeeTimeFlag
            BillingRate
            TotalBill
            EmployeeTimeFlag
            EmployeeRateFrom
            EmployeeCommissionPercent
            ExtendedMarkupAmount
            TaxCode
            TaxStatePercent
            TaxCountyPercent
            TaxCityPercent
            TaxResale
            TaxCommission
            TaxCommissionOnly
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            LineTotal
            AdjusterComments
            SalesClassCode
            TaskCode
            TaskDescription
            Assignment
        End Enum

        Public Enum EmployeeTimeFlags
            Unbilled = 0
            Billed = 1
            Indirect = 2
            SelectedForBilling = 3
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeNonBillableFlag As Nullable(Of Short) = Nothing
        Private _BillingRate As Nullable(Of Decimal) = Nothing
        Private _ChangeLog As Generic.Dictionary(Of String, Boolean) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:=" ", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property EmployeeTimeFlag() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTimeID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTimeDetailID() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee", IsReadOnlyColumn:=True)>
        Public Property EmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property EmployeeName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date", IsReadOnlyColumn:=True)>
        Public Property EmployeeDate() As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Dept / Team", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Dept / Team Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DepartmentTeamName)>
        Public Property DepartmentTeamDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee Title", PropertyType:=BaseClasses.PropertyTypes.EmployeeTitleID)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property ProductDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job", IsReadOnlyColumn:=True)>
        Public Property JobNumber() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property JobDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp", IsReadOnlyColumn:=True)>
        Public Property JobComponentNumber() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp Description", IsReadOnlyColumn:=True)>
        Public Property JobComponentDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Assignment")>
        Public Property Assignment() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function", IsReadOnlyColumn:=True)>
        Public Property FunctionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property FunctionDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Hours", IsReadOnlyColumn:=True)>
        Public Property EmployeeHours() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billable", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
        Public Property EmployeeNonBillableFlag() As Nullable(Of Short)
            Get
                EmployeeNonBillableFlag = _EmployeeNonBillableFlag
            End Get
            Set(value As Nullable(Of Short))
                _EmployeeNonBillableFlag = value
                SetPropertyAutomaticallyChanged("EmployeeNonBillableFlag", False)
            End Set
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="")>
        Public Property FeeTimeFlag() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="")>
        Public Property BillingRate() As Nullable(Of Decimal)
            Get
                BillingRate = _BillingRate
            End Get
            Set(value As Nullable(Of Decimal))
                _BillingRate = value
                SetPropertyAutomaticallyChanged("BillingRate", False)
            End Set
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Total", IsReadOnlyColumn:=True)>
        Public Property TotalBill() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeRateFrom() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCommissionPercent() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxStatePercent() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCountyPercent() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCityPercent() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxResale() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCommission() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCommissionOnly() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedStateResale() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCountyResale() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCityResale() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineTotal() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AdjusterComments() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesClassCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaskCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaskDescription() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTimeID.ToString

        End Function
        Public Sub SetPropertyAutomaticallyChanged(ByVal PropertyName As String, ByVal AutomaticallyChanged As Boolean)

            If _ChangeLog Is Nothing Then

                _ChangeLog = New Generic.Dictionary(Of String, Boolean)

            End If

            _ChangeLog(PropertyName.ToString) = AutomaticallyChanged

        End Sub
        Public Function GetPropertyAutomaticallyChanged(ByVal PropertyName As String) As Boolean

            'objects
            Dim AutomaticallyChanged As Boolean = False

            If _ChangeLog IsNot Nothing Then

                If _ChangeLog.ContainsKey(PropertyName.ToString) Then

                    AutomaticallyChanged = _ChangeLog(PropertyName.ToString)

                End If

            End If

            GetPropertyAutomaticallyChanged = AutomaticallyChanged

        End Function

#End Region

    End Class

End Namespace
