Namespace Database.Classes

    <Serializable()>
    Public Class PurchaseOrderApprovalRuleDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PurchaseOrderApprovalRuleDetail
            PurchaseOrderApprovalRuleCode
            POApprovalRule
            SequenceNumber
            ApprovalMinimum
            ApprovalMaximum
            IsInactive
            EmployeeName
            EmployeeName2
            EmployeeName3
            EmployeeName4
            EmployeeName5
            EmployeeName6
            EmployeeName7
            EmployeeName8
            EmployeeName9
            EmployeeName10
        End Enum

#End Region

#Region " Variables "

        Private _PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail = Nothing
        Private _PurchaseOrderApprovalRuleEmployees As ICollection(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) = Nothing
        Private _EmployeeName As String = Nothing
        Private _EmployeeName2 As String = Nothing
        Private _EmployeeName3 As String = Nothing
        Private _EmployeeName4 As String = Nothing
        Private _EmployeeName5 As String = Nothing
        Private _EmployeeName6 As String = Nothing
        Private _EmployeeName7 As String = Nothing
        Private _EmployeeName8 As String = Nothing
        Private _EmployeeName9 As String = Nothing
        Private _EmployeeName10 As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail
            Get
                PurchaseOrderApprovalRuleDetail = _PurchaseOrderApprovalRuleDetail
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property PurchaseOrderApprovalRuleCode As String
            Get
                PurchaseOrderApprovalRuleCode = _PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
            End Get
            Set(ByVal value As String)
                _PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property POApprovalRule As String
            Get

                Try

                    POApprovalRule = _PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRule.ToString

                Catch ex As Exception
                    POApprovalRule = ""
                End Try

            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SequenceNumber As Short
            Get
                SequenceNumber = _PurchaseOrderApprovalRuleDetail.SequenceNumber
            End Get
            Set(ByVal value As Short)
                _PurchaseOrderApprovalRuleDetail.SequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ApprovalMinimum As Nullable(Of Decimal)
            Get
                ApprovalMinimum = _PurchaseOrderApprovalRuleDetail.ApprovalMinimum
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PurchaseOrderApprovalRuleDetail.ApprovalMinimum = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ApprovalMaximum As Nullable(Of Decimal)
            Get
                ApprovalMaximum = _PurchaseOrderApprovalRuleDetail.ApprovalMaximum
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PurchaseOrderApprovalRuleDetail.ApprovalMaximum = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive As Nullable(Of Short)
            Get
                IsInactive = _PurchaseOrderApprovalRuleDetail.IsInactive.GetValueOrDefault(0)
            End Get
            Set(ByVal value As Nullable(Of Short))
                _PurchaseOrderApprovalRuleDetail.IsInactive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Primary Approver", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(ByVal value As String)
                _EmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 1", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName2 As String
            Get
                EmployeeName2 = _EmployeeName2
            End Get
            Set(ByVal value As String)
                _EmployeeName2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 2", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName3 As String
            Get
                EmployeeName3 = _EmployeeName3
            End Get
            Set(ByVal value As String)
                _EmployeeName3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 3", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName4 As String
            Get
                EmployeeName4 = _EmployeeName4
            End Get
            Set(ByVal value As String)
                _EmployeeName4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 4", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName5 As String
            Get
                EmployeeName5 = _EmployeeName5
            End Get
            Set(ByVal value As String)
                _EmployeeName5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 5", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName6 As String
            Get
                EmployeeName6 = _EmployeeName6
            End Get
            Set(ByVal value As String)
                _EmployeeName6 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 6", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName7 As String
            Get
                EmployeeName7 = _EmployeeName7
            End Get
            Set(ByVal value As String)
                _EmployeeName7 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 7", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName8 As String
            Get
                EmployeeName8 = _EmployeeName8
            End Get
            Set(ByVal value As String)
                _EmployeeName8 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 8", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName9 As String
            Get
                EmployeeName9 = _EmployeeName9
            End Get
            Set(ByVal value As String)
                _EmployeeName9 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alternate Approver 9", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeName10 As String
            Get
                EmployeeName10 = _EmployeeName10
            End Get
            Set(ByVal value As String)
                _EmployeeName10 = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _PurchaseOrderApprovalRuleDetail = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail)

            _PurchaseOrderApprovalRuleDetail = PurchaseOrderApprovalRuleDetail

            Try

                _PurchaseOrderApprovalRuleEmployees = _PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleEmployees
                SetEmployeeNames(DbContext, _PurchaseOrderApprovalRuleEmployees)

            Catch ex As Exception
                _PurchaseOrderApprovalRuleEmployees = Nothing
            End Try

        End Sub
        Private Sub SetEmployeeNames(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Employees As ICollection(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee))

            Dim PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing

            For Each Employee In (Employees.Where(Function(Entity) Entity.IsInactive.GetValueOrDefault(0) = 0).OrderBy(Function(Entity) Entity.Order))

                If _EmployeeName Is Nothing Then

                    _EmployeeName = Employee.EmployeeCode

                ElseIf _EmployeeName2 Is Nothing Then

                    _EmployeeName2 = Employee.EmployeeCode

                ElseIf _EmployeeName3 Is Nothing Then

                    _EmployeeName3 = Employee.EmployeeCode

                ElseIf _EmployeeName4 Is Nothing Then

                    _EmployeeName4 = Employee.EmployeeCode

                ElseIf _EmployeeName5 Is Nothing Then

                    _EmployeeName5 = Employee.EmployeeCode

                ElseIf _EmployeeName6 Is Nothing Then

                    _EmployeeName6 = Employee.EmployeeCode

                ElseIf _EmployeeName7 Is Nothing Then

                    _EmployeeName7 = Employee.EmployeeCode

                ElseIf _EmployeeName8 Is Nothing Then

                    _EmployeeName8 = Employee.EmployeeCode

                ElseIf _EmployeeName9 Is Nothing Then

                    _EmployeeName9 = Employee.EmployeeCode

                ElseIf _EmployeeName10 Is Nothing Then

                    _EmployeeName10 = Employee.EmployeeCode

                End If

            Next

        End Sub

#End Region

    End Class

End Namespace
