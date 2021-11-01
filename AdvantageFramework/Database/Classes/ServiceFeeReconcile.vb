Namespace Database.Classes

    <Serializable()>
    Public Class ServiceFeeReconcile
        Implements AdvantageFramework.BaseClasses.Interfaces.IValidatingClass

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
            FunctionType
            FunctionOrderNumber
            FeeQuantity
            FeeAmount
            ReconciledHours
            ReconciledAmount
            UnreconciledHours
            UnreconciledAmount
            TotalHours
            TotalAmount
            FeeTimeType
            IsServiceFeeJob
            FeeDate
            Description
            Comment
            EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode
            JobServiceFeeTypeCode
            EmployeeDepartmentTeamServiceFeeTypeCode
            Reconcile
            MediaType
            PostPeriodCode
            FunctionHeading
            FunctionHeadingOrderNumber
            FunctionConsolidation
            FunctionConsolidationType
            FunctionConsolidationOrderNumber
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
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
        Private _ComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponent As String = Nothing
        Private _ComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionOrderNumber As Nullable(Of Short) = Nothing
        Private _FeeQuantity As Nullable(Of Decimal) = Nothing
        Private _FeeAmount As Nullable(Of Decimal) = Nothing
        Private _ReconciledHours As Nullable(Of Decimal) = Nothing
        Private _ReconciledAmount As Nullable(Of Decimal) = Nothing
        Private _UnreconciledHours As Nullable(Of Decimal) = Nothing
        Private _UnreconciledAmount As Nullable(Of Decimal) = Nothing
        Private _TotalHours As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _FeeTimeType As String = Nothing
        Private _IsServiceFeeJob As Boolean = Nothing
        Private _FeeDate As Nullable(Of Date) = Nothing
        Private _Description As String = Nothing
        Private _Comment As String = Nothing
        Private _EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode As String = Nothing
        Private _JobServiceFeeTypeCode As String = Nothing
        Private _EmployeeDepartmentTeamServiceFeeTypeCode As String = Nothing
        Private _Reconcile As Boolean = Nothing
        Private _MediaType As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _FunctionHeading As String = Nothing
        Private _FunctionHeadingOrderNumber As Nullable(Of Integer) = Nothing
        Private _FunctionConsolidation As String = Nothing
        Private _FunctionConsolidationType As String = Nothing
        Private _FunctionConsolidationOrderNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(ByVal value As String)
                _ClientDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(ByVal value As String)
                _DivisionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentNumber() As Nullable(Of Short)
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionOrderNumber() As Nullable(Of Short)
            Get
                FunctionOrderNumber = _FunctionOrderNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FunctionOrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeDate() As Nullable(Of Date)
            Get
                FeeDate = _FeeDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _FeeDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeQuantity() As Nullable(Of Decimal)
            Get
                FeeQuantity = _FeeQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _FeeQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeAmount() As Nullable(Of Decimal)
            Get
                FeeAmount = _FeeAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _FeeAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReconciledHours() As Nullable(Of Decimal)
            Get
                ReconciledHours = _ReconciledHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ReconciledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReconciledAmount() As Nullable(Of Decimal)
            Get
                ReconciledAmount = _ReconciledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ReconciledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UnreconciledHours() As Nullable(Of Decimal)
            Get
                UnreconciledHours = _UnreconciledHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _UnreconciledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UnreconciledAmount() As Nullable(Of Decimal)
            Get
                UnreconciledAmount = _UnreconciledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _UnreconciledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalHours() As Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeTimeType() As String
            Get
                FeeTimeType = _FeeTimeType
            End Get
            Set(ByVal value As String)
                _FeeTimeType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsServiceFeeJob() As Boolean
            Get
                IsServiceFeeJob = _IsServiceFeeJob
            End Get
            Set(ByVal value As Boolean)
                _IsServiceFeeJob = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode() As String
            Get
                EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode = _EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode
            End Get
            Set(ByVal value As String)
                _EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobServiceFeeTypeCode() As String
            Get
                JobServiceFeeTypeCode = _JobServiceFeeTypeCode
            End Get
            Set(ByVal value As String)
                _JobServiceFeeTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeDepartmentTeamServiceFeeTypeCode() As String
            Get
                EmployeeDepartmentTeamServiceFeeTypeCode = _EmployeeDepartmentTeamServiceFeeTypeCode
            End Get
            Set(ByVal value As String)
                _EmployeeDepartmentTeamServiceFeeTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Reconcile() As Boolean
            Get
                Reconcile = _Reconcile
            End Get
            Set(ByVal value As Boolean)
                _Reconcile = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(ByVal value As String)
                _MediaType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(ByVal value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(ByVal value As String)
                _FunctionHeading = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingOrderNumber() As Nullable(Of Integer)
            Get
                FunctionHeadingOrderNumber = _FunctionHeadingOrderNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionHeadingOrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidation() As String
            Get
                FunctionConsolidation = _FunctionConsolidation
            End Get
            Set(ByVal value As String)
                _FunctionConsolidation = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationType() As String
            Get
                FunctionConsolidationType = _FunctionConsolidationType
            End Get
            Set(ByVal value As String)
                _FunctionConsolidationType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationOrderNumber() As Nullable(Of Short)
            Get
                FunctionConsolidationOrderNumber = _FunctionConsolidationOrderNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FunctionConsolidationOrderNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Classes.ServiceFeeReconcile

            'objects
            Dim NewServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile = Nothing

            NewServiceFeeReconcileDetail = New AdvantageFramework.Database.Classes.ServiceFeeReconcile

            NewServiceFeeReconcileDetail.ID = Me.ID
            NewServiceFeeReconcileDetail.JobNumber = Me.JobNumber
            NewServiceFeeReconcileDetail.ClientCode = Me.ClientCode
            NewServiceFeeReconcileDetail.ClientDescription = Me.ClientDescription
            NewServiceFeeReconcileDetail.DivisionCode = Me.DivisionCode
            NewServiceFeeReconcileDetail.DivisionDescription = Me.DivisionDescription
            NewServiceFeeReconcileDetail.ProductCode = Me.ProductCode
            NewServiceFeeReconcileDetail.ProductDescription = Me.ProductDescription
            NewServiceFeeReconcileDetail.CampaignCode = Me.CampaignCode
            NewServiceFeeReconcileDetail.CampaignName = Me.CampaignName
            NewServiceFeeReconcileDetail.SalesClassCode = Me.SalesClassCode
            NewServiceFeeReconcileDetail.SalesClassDescription = Me.SalesClassDescription
            NewServiceFeeReconcileDetail.JobDescription = Me.JobDescription
            NewServiceFeeReconcileDetail.ComponentNumber = Me.ComponentNumber
            NewServiceFeeReconcileDetail.JobComponent = Me.JobComponent
            NewServiceFeeReconcileDetail.ComponentDescription = Me.ComponentDescription
            NewServiceFeeReconcileDetail.FunctionCode = Me.FunctionCode
            NewServiceFeeReconcileDetail.FunctionDescription = Me.FunctionDescription
            NewServiceFeeReconcileDetail.FeeQuantity = Me.FeeQuantity
            NewServiceFeeReconcileDetail.FeeAmount = Me.FeeAmount
            NewServiceFeeReconcileDetail.ReconciledHours = Me.ReconciledHours
            NewServiceFeeReconcileDetail.ReconciledAmount = Me.ReconciledAmount
            NewServiceFeeReconcileDetail.UnreconciledHours = Me.UnreconciledHours
            NewServiceFeeReconcileDetail.UnreconciledAmount = Me.UnreconciledAmount
            NewServiceFeeReconcileDetail.TotalHours = Me.TotalHours
            NewServiceFeeReconcileDetail.TotalAmount = Me.TotalAmount
            NewServiceFeeReconcileDetail.FeeTimeType = Me.FeeTimeType
            NewServiceFeeReconcileDetail.IsServiceFeeJob = Me.IsServiceFeeJob
            NewServiceFeeReconcileDetail.FeeDate = Me.FeeDate
            NewServiceFeeReconcileDetail.Description = Me.Description
            NewServiceFeeReconcileDetail.Comment = Me.Comment
            NewServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode = Me.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode
            NewServiceFeeReconcileDetail.JobServiceFeeTypeCode = Me.JobServiceFeeTypeCode
            NewServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode = Me.EmployeeDepartmentTeamServiceFeeTypeCode
            NewServiceFeeReconcileDetail.Reconcile = Me.Reconcile
            NewServiceFeeReconcileDetail.MediaType = Me.MediaType
            NewServiceFeeReconcileDetail.PostPeriodCode = Me.PostPeriodCode

            Copy = NewServiceFeeReconcileDetail

        End Function
        Public Function CreateXML() As String Implements BaseClasses.Interfaces.IValidatingClass.CreateXML

            CreateXML = AdvantageFramework.BaseClasses.CreateXML(Me)

        End Function
        Public Function HasError() As Boolean Implements BaseClasses.Interfaces.IValidatingClass.HasError

            'objects
            Dim EntityHasError As Boolean = False

            Try

                'If IsNothing(_EntityError) = False AndAlso _EntityError <> "" Then

                '    EntityHasError = True

                'End If

            Catch ex As Exception
                EntityHasError = False
            End Try

            HasError = EntityHasError

        End Function
        Public Function ImportFromXML(XML As String) As BaseClasses.Entity Implements BaseClasses.Interfaces.IValidatingClass.ImportFromXML

            ImportFromXML = AdvantageFramework.BaseClasses.ImportFromXML(XML, Me.GetType)

        End Function
        Public Function IsRequiredProperty(Type As Type, PropertyName As String) As Boolean Implements BaseClasses.Interfaces.IValidatingClass.IsRequiredProperty

            IsRequiredProperty = False

        End Function
        Public Function ValidateEntity(ByRef IsValid As Boolean) As String Implements BaseClasses.Interfaces.IValidatingClass.ValidateEntity

            ValidateEntity = ""

        End Function
        Public Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String Implements BaseClasses.Interfaces.IValidatingClass.ValidateEntityProperty

            ValidateEntityProperty = ""

        End Function

#End Region

    End Class

End Namespace
