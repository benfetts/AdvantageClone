Namespace Database.Views

    <Table("V_SERVICE_FEE_RECON")>
    Public Class ServiceFeeReconcileDetail
        Inherits BaseClasses.EntityView

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



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Long
        <Column("JobNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
        <Required>
        <MaxLength(6)>
        <Column("ClientCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <Column("ClientDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDescription() As String
        <MaxLength(6)>
        <Column("DivisionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <Column("DivisionDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionDescription() As String
        <MaxLength(6)>
        <Column("ProductCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <Column("ProductDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
        <MaxLength(6)>
        <Column("CampaignCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
        <MaxLength(60)>
        <Column("CampaignName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
        <MaxLength(6)>
        <Column("SalesClassCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
        <MaxLength(30)>
        <Column("SalesClassDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
        <MaxLength(60)>
        <Column("JobDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
        <Column("ComponentNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentNumber() As Nullable(Of Short)
        <MaxLength(9)>
        <Column("JobComponent", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
        <MaxLength(60)>
        <Column("ComponentDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDescription() As String
        <MaxLength(6)>
        <Column("FunctionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
        <MaxLength(30)>
        <Column("FunctionDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
        <MaxLength(1)>
        <Column("FunctionType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionType() As String
        <Column("FunctionOrderNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionOrderNumber() As Nullable(Of Short)
        <Column("FeeQuantity")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeQuantity() As Nullable(Of Decimal)
        <Column("FeeAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeAmount() As Nullable(Of Decimal)
        <Column("ReconciledHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReconciledHours() As Nullable(Of Decimal)
        <Column("ReconciledAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReconciledAmount() As Nullable(Of Decimal)
        <Column("UnreconciledHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UnreconciledHours() As Nullable(Of Decimal)
        <Column("UnreconciledAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UnreconciledAmount() As Nullable(Of Decimal)
        <Column("TotalHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalHours() As Nullable(Of Decimal)
        <Column("TotalAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalAmount() As Nullable(Of Decimal)
        <Required>
        <MaxLength(17)>
        <Column("FeeTimeType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeTimeType() As String
        <Required>
        <Column("IsServiceFeeJob")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsServiceFeeJob() As Boolean
        <Column("FeeDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FeeDate() As Nullable(Of Date)
		<Column("Description", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Column("Comment")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Comment() As String
        <MaxLength(6)>
        <Column("EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode() As String
        <MaxLength(6)>
        <Column("JobServiceFeeTypeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobServiceFeeTypeCode() As String
        <MaxLength(6)>
        <Column("EmployeeDepartmentTeamServiceFeeTypeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeDepartmentTeamServiceFeeTypeCode() As String
        <Required>
        <Column("Reconcile")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Reconcile() As Boolean
        <MaxLength(1)>
        <Column("MediaType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType() As String
        <MaxLength(6)>
        <Column("PostPeriodCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String
        <MaxLength(60)>
        <Column("FunctionHeading", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeading() As String
        <Column("FunctionHeadingOrderNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingOrderNumber() As Nullable(Of Integer)
        <MaxLength(30)>
        <Column("FunctionConsolidation", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidation() As String
        <MaxLength(1)>
        <Column("FunctionConsolidationType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationType() As String
        <Column("FunctionConsolidationOrderNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationOrderNumber() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Function Copy() As AdvantageFramework.Database.Views.ServiceFeeReconcileDetail

            'objects
            Dim NewServiceFeeReconcileDetail As AdvantageFramework.Database.Views.ServiceFeeReconcileDetail = Nothing

            NewServiceFeeReconcileDetail = New AdvantageFramework.Database.Views.ServiceFeeReconcileDetail

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

#End Region

    End Class

End Namespace
