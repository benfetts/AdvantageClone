Namespace Database.Classes

    <Serializable()>
    Public Class ServiceFeeReconcileDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            CampaignCode
            CampaignName
            SalesClassCode
            SalesClassDescription
            JobDescription
            ComponentNumber
            JobComponent
            ComponentDescription
            FunctionCode
            FunctionDescription
            ReconciledHours
            ReconciledAmount
            UnreconciledHours
            UnreconciledAmount
            FeeTimeType
            IsServiceFeeJob
            EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode
            JobServiceFeeTypeCode
            EmployeeDepartmentTeamServiceFeeTypeCode
            FeeDate
            Description
            FeeQuantity
            FeeAmount
            TotalHours
            TotalAmount
            Comment
            Reconcile
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _JobNumber As Integer = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Short = Nothing
        Private _JobComponent As String = Nothing
        Private _ComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _ReconciledHours As Nullable(Of Decimal) = Nothing
        Private _ReconciledAmount As Nullable(Of Decimal) = Nothing
        Private _UnreconciledHours As Nullable(Of Decimal) = Nothing
        Private _UnreconciledAmount As Nullable(Of Decimal) = Nothing
        Private _IsServiceFeeJob As Boolean = Nothing
        Private _EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode As String = Nothing
        Private _JobServiceFeeTypeCode As String = Nothing
        Private _EmployeeDepartmentTeamServiceFeeTypeCode As String = Nothing
        Private _FeeDate As Date = Nothing
        Private _Description As String = Nothing
        Private _FeeQuantity As Nullable(Of Decimal) = Nothing
        Private _FeeAmount As Nullable(Of Decimal) = Nothing
        Private _TotalHours As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _Comment As String = Nothing
        Private _FeeTimeType As String = Nothing
        Private _Reconcile As Boolean = Nothing
        Private _ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
        Private _HasList As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As System.Guid
            Get
                ID = _ID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ComponentNumber() As Short
            Get
                ComponentNumber = _ComponentNumber
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ReconciledHours() As Nullable(Of Decimal)
            Get
                ReconciledHours = _ReconciledHours
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ReconciledAmount() As Nullable(Of Decimal)
            Get
                ReconciledAmount = _ReconciledAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property UnreconciledHours() As Nullable(Of Decimal)
            Get
                UnreconciledHours = _UnreconciledHours
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property UnreconciledAmount() As Nullable(Of Decimal)
            Get
                UnreconciledAmount = _UnreconciledAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property IsServiceFeeJob() As Boolean
            Get
                IsServiceFeeJob = _IsServiceFeeJob
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode() As String
            Get
                EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode = _EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property JobServiceFeeTypeCode() As String
            Get
                JobServiceFeeTypeCode = _JobServiceFeeTypeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property EmployeeDepartmentTeamServiceFeeTypeCode() As String
            Get
                EmployeeDepartmentTeamServiceFeeTypeCode = _EmployeeDepartmentTeamServiceFeeTypeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property FeeDate() As Date
            Get
                FeeDate = _FeeDate
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property Description() As String
            Get
                Description = _Description
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property FeeQuantity() As Nullable(Of Decimal)
            Get
                FeeQuantity = _FeeQuantity
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property FeeAmount() As Nullable(Of Decimal)
            Get
                FeeAmount = _FeeAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property TotalHours() As Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property Comment() As String
            Get
                Comment = _Comment
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property FeeTimeType() As String
            Get
                FeeTimeType = _FeeTimeType
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property Reconcile() As Boolean
            Get
                Reconcile = _Reconcile
            End Get
            Set(value As Boolean)
                _Reconcile = value
            End Set
        End Property
        '<System.ComponentModel.Browsable(False),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public ReadOnly Property ServiceFeeReconcileDetailList() As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)
        '    Get
        '        ServiceFeeReconcileDetailList = _ServiceFeeReconcileDetailList
        '    End Get
        'End Property
        '<System.ComponentModel.Browsable(False),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public ReadOnly Property HasList() As Boolean
        '    Get
        '        HasList = _HasList
        '    End Get
        'End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile))

            'objects
            Dim ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile = Nothing

            _ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList
            _HasList = True

            Try

                ServiceFeeReconcileDetail = ServiceFeeReconcileDetailList.FirstOrDefault

            Catch ex As Exception
                ServiceFeeReconcileDetail = Nothing
            End Try

            If ServiceFeeReconcileDetail IsNot Nothing Then

                _ID = ServiceFeeReconcileDetail.ID
                _JobNumber = ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0)
                _ClientCode = ServiceFeeReconcileDetail.ClientCode
                _ClientDescription = ServiceFeeReconcileDetail.ClientDescription
                _DivisionCode = ServiceFeeReconcileDetail.DivisionCode
                _DivisionDescription = ServiceFeeReconcileDetail.DivisionDescription
                _ProductCode = ServiceFeeReconcileDetail.ProductCode
                _ProductDescription = ServiceFeeReconcileDetail.ProductDescription
                _CampaignCode = ServiceFeeReconcileDetail.CampaignCode
                _CampaignName = ServiceFeeReconcileDetail.CampaignName
                _SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode
                _SalesClassDescription = ServiceFeeReconcileDetail.SalesClassDescription
                _JobDescription = ServiceFeeReconcileDetail.JobDescription
                _ComponentNumber = ServiceFeeReconcileDetail.ComponentNumber.GetValueOrDefault(0)
                _JobComponent = ServiceFeeReconcileDetail.JobComponent
                _ComponentDescription = ServiceFeeReconcileDetail.ComponentDescription
                _FunctionCode = ServiceFeeReconcileDetail.FunctionCode
                _FunctionDescription = ServiceFeeReconcileDetail.FunctionDescription

                If ServiceFeeReconcileDetail.FeeTimeType.Contains("Billed") Then

                    _FeeQuantity = _ServiceFeeReconcileDetailList.Sum(Function(EntityView) EntityView.FeeQuantity)
                    _FeeAmount = _ServiceFeeReconcileDetailList.Sum(Function(EntityView) EntityView.FeeAmount)

                End If

                _ReconciledHours = ServiceFeeReconcileDetail.ReconciledHours
                _ReconciledAmount = ServiceFeeReconcileDetail.ReconciledAmount
                _UnreconciledHours = ServiceFeeReconcileDetail.UnreconciledHours
                _UnreconciledAmount = ServiceFeeReconcileDetail.UnreconciledAmount

                If ServiceFeeReconcileDetail.FeeTimeType.Contains("Billed") = False Then

                    _TotalHours = _ServiceFeeReconcileDetailList.Sum(Function(EntityView) EntityView.TotalHours)
                    _TotalAmount = _ServiceFeeReconcileDetailList.Sum(Function(EntityView) EntityView.TotalAmount)

                End If

                _FeeTimeType = ServiceFeeReconcileDetail.FeeTimeType
                _IsServiceFeeJob = ServiceFeeReconcileDetail.IsServiceFeeJob
                _FeeDate = ServiceFeeReconcileDetail.FeeDate.GetValueOrDefault(Date.MinValue)
                _Description = ServiceFeeReconcileDetail.Description
                _Comment = ServiceFeeReconcileDetail.Comment
                _EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode = ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode
                _JobServiceFeeTypeCode = ServiceFeeReconcileDetail.JobServiceFeeTypeCode
                _EmployeeDepartmentTeamServiceFeeTypeCode = ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode
                _Reconcile = ServiceFeeReconcileDetail.Reconcile

            End If

        End Sub
        Public Sub New(ByVal ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile)

            _ID = ServiceFeeReconcileDetail.ID
            _JobNumber = ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0)
            _ClientCode = ServiceFeeReconcileDetail.ClientCode
            _ClientDescription = ServiceFeeReconcileDetail.ClientDescription
            _DivisionCode = ServiceFeeReconcileDetail.DivisionCode
            _DivisionDescription = ServiceFeeReconcileDetail.DivisionDescription
            _ProductCode = ServiceFeeReconcileDetail.ProductCode
            _ProductDescription = ServiceFeeReconcileDetail.ProductDescription
            _CampaignCode = ServiceFeeReconcileDetail.CampaignCode
            _CampaignName = ServiceFeeReconcileDetail.CampaignName
            _SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode
            _SalesClassDescription = ServiceFeeReconcileDetail.SalesClassDescription
            _JobDescription = ServiceFeeReconcileDetail.JobDescription
            _ComponentNumber = ServiceFeeReconcileDetail.ComponentNumber.GetValueOrDefault(0)
            _JobComponent = ServiceFeeReconcileDetail.JobComponent
            _ComponentDescription = ServiceFeeReconcileDetail.ComponentDescription
            _FunctionCode = ServiceFeeReconcileDetail.FunctionCode
            _FunctionDescription = ServiceFeeReconcileDetail.FunctionDescription
            _FeeQuantity = ServiceFeeReconcileDetail.FeeQuantity
            _FeeAmount = ServiceFeeReconcileDetail.FeeAmount
            _ReconciledHours = ServiceFeeReconcileDetail.ReconciledHours
            _ReconciledAmount = ServiceFeeReconcileDetail.ReconciledAmount
            _UnreconciledHours = ServiceFeeReconcileDetail.UnreconciledHours
            _UnreconciledAmount = ServiceFeeReconcileDetail.UnreconciledAmount
            _TotalHours = ServiceFeeReconcileDetail.TotalHours
            _TotalAmount = ServiceFeeReconcileDetail.TotalAmount
            _FeeTimeType = ServiceFeeReconcileDetail.FeeTimeType
            _IsServiceFeeJob = ServiceFeeReconcileDetail.IsServiceFeeJob
            _FeeDate = ServiceFeeReconcileDetail.FeeDate.GetValueOrDefault(Date.MinValue)
            _Description = ServiceFeeReconcileDetail.Description
            _Comment = ServiceFeeReconcileDetail.Comment
            _EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode = ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode
            _JobServiceFeeTypeCode = ServiceFeeReconcileDetail.JobServiceFeeTypeCode
            _EmployeeDepartmentTeamServiceFeeTypeCode = ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode
            _Reconcile = ServiceFeeReconcileDetail.Reconcile
            _ServiceFeeReconcileDetailList = Nothing
            _HasList = False

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
