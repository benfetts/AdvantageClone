Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class ProductionProcessControl
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            ComponentNumber
            ComponentDescription
            ProcessControlDescription
            NewProcessControl
            QualifiedToClose
            ProcessControlComments
            ScheduleStatus
            NewScheduleStatus
            EstimateAmount
            ActualBillableAmount
            OpenPOAmount
            BilledAmount
            UnbilledAmount
            AdvanceBilledAmount
            UnbilledAdvanceAmount
            TotalBilledAmount
            FlatIncomeRecognized
            BillingApprovalHeaderComment
            IsNonBillable
            ProcessedDate
            CreatedDate
            LastProcessControl
            ScheduleCompletedDate
        End Enum

#End Region

#Region " Variables "

        Private _ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
        Private _NewProcessControl As Nullable(Of Short) = Nothing
        Private _ProcessControlComments As String = Nothing
        Private _NewScheduleStatus As String = Nothing
        Private _IsNonBillable As Boolean = False
        Private _ProcessedDate As Nullable(Of Date) = Nothing
        Private _CreatedDate As Nullable(Of Date) = Nothing
        Private _LastProcessControl As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary
            Get
                ProductionSummary = _ProductionSummary
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _ProductionSummary.ClientCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ClientName() As String
            Get
                ClientName = _ProductionSummary.ClientName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DivisionCode() As String
            Get
                DivisionCode = _ProductionSummary.DivisionCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DivisionName() As String
            Get
                DivisionName = _ProductionSummary.DivisionName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ProductCode() As String
            Get
                ProductCode = _ProductionSummary.ProductCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ProductDescription() As String
            Get
                ProductDescription = _ProductionSummary.ProductDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property JobNumber() As Integer
            Get
                JobNumber = _ProductionSummary.JobNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property JobDescription() As String
            Get
                JobDescription = _ProductionSummary.JobDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component")>
        Public ReadOnly Property ComponentNumber() As Short
            Get
                ComponentNumber = _ProductionSummary.ComponentNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
                AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ComponentDescription() As String
            Get
                ComponentDescription = _ProductionSummary.ComponentDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Process Control")>
        Public ReadOnly Property ProcessControlDescription() As String
            Get
                ProcessControlDescription = _ProductionSummary.ProcessControlDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.JobProcess)>
        Public Property NewProcessControl() As Nullable(Of Short)
            Get
                NewProcessControl = _NewProcessControl
            End Get
            Set(value As Nullable(Of Short))
                _NewProcessControl = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property QualifiedToClose() As Boolean
            Get
                QualifiedToClose = _ProductionSummary.IsCloseable
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property ProcessControlComments() As String
            Get
                ProcessControlComments = _ProcessControlComments
            End Get
            Set(value As String)
                _ProcessControlComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ScheduleStatus() As String
            Get
                ScheduleStatus = _ProductionSummary.ScheduleStatus
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.Status)>
        Public Property NewScheduleStatus() As String
            Get
                NewScheduleStatus = _NewScheduleStatus
            End Get
            Set(value As String)
                _NewScheduleStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property EstimateAmount() As Decimal
            Get
                EstimateAmount = _ProductionSummary.EstimateAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property ActualBillableAmount() As Nullable(Of Decimal)
            Get
                ActualBillableAmount = _ProductionSummary.ActualBillableAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property OpenPOAmount() As Nullable(Of Decimal)
            Get
                OpenPOAmount = _ProductionSummary.OpenPOAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _ProductionSummary.BilledAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property UnbilledAmount() As Nullable(Of Decimal)
            Get
                UnbilledAmount = _ProductionSummary.UnbilledAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property AdvanceBilledAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledAmount = _ProductionSummary.AdvanceBilledAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property UnbilledAdvanceAmount() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceAmount = _ProductionSummary.UnbilledAdvanceAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property TotalBilledAmount() As Nullable(Of Decimal)
            Get
                TotalBilledAmount = _ProductionSummary.TotalBilledAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property FlatIncomeRecognized() As Nullable(Of Decimal)
            Get
                FlatIncomeRecognized = _ProductionSummary.FlatIncomeRecognized
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property IsNonBillable() As Boolean
            Get
                IsNonBillable = _IsNonBillable
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date Opened")>
        Public ReadOnly Property CreatedDate() As Nullable(Of Date)
            Get
                CreatedDate = _CreatedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Process Control Date")>
        Public ReadOnly Property ProcessedDate() As Nullable(Of Date)
            Get
                ProcessedDate = _ProcessedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property LastProcessControl() As String
            Get
                LastProcessControl = _LastProcessControl
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billing Approval Comment")>
        Public ReadOnly Property BillingApprovalHeaderComment() As String
            Get
                BillingApprovalHeaderComment = _ProductionSummary.BillingApprovalHeaderComment
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ScheduleCompletedDate() As Nullable(Of Date)
            Get
                ScheduleCompletedDate = _ProductionSummary.ScheduleCompletedDate
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary,
                       ByVal JobProcessList As Generic.List(Of AdvantageFramework.Database.Entities.JobProcess))

            Dim JobProcessLog As AdvantageFramework.Database.Entities.JobProcessLog = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobProcess As AdvantageFramework.Database.Entities.JobProcess = Nothing

            _ProductionSummary = ProductionSummary

            JobProcessLog = AdvantageFramework.Database.Procedures.JobProcessLog.LoadLatestByJobComponent(DbContext, _ProductionSummary.JobNumber, _ProductionSummary.ComponentNumber)

            If JobProcessLog IsNot Nothing Then

                _ProcessedDate = JobProcessLog.ProcessedDate

                If JobProcessLog.OriginalProcessControl.HasValue Then

                    JobProcess = JobProcessList.Where(Function(JP) JP.ID = JobProcessLog.OriginalProcessControl.Value).FirstOrDefault

                    If JobProcess IsNot Nothing Then

                        _LastProcessControl = JobProcess.Description

                    End If

                End If

                _ProcessControlComments = JobProcessLog.Comments

            End If

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, _ProductionSummary.JobNumber, _ProductionSummary.ComponentNumber)

            If JobComponent IsNot Nothing Then

                _IsNonBillable = CBool(JobComponent.IsNonbillable.GetValueOrDefault(0))

                _CreatedDate = JobComponent.CreatedDate

            End If

        End Sub

#End Region

    End Class

End Namespace
