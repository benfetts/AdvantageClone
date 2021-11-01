Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class ProductionBillHold
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
            BillStatus
            BillHoldAmount
            JobBillHoldRequested
            BillingApprovalHeaderComment
            NewBillHoldStatus
        End Enum

#End Region

#Region " Variables "

        Private _ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
        Private _NewBillHoldStatus As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _ProductionSummary.ClientCode
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component")>
        Public ReadOnly Property ComponentNumber() As Short
            Get
                ComponentNumber = _ProductionSummary.ComponentNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Bill Status")>
        Public ReadOnly Property BillStatus() As Integer
            Get
                BillStatus = _ProductionSummary.BillStatus
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NewBillHoldStatus() As Nullable(Of Integer)
            Get
                NewBillHoldStatus = _NewBillHoldStatus
            End Get
            Set(value As Nullable(Of Integer))
                _NewBillHoldStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property JobDescription() As String
            Get
                JobDescription = _ProductionSummary.JobDescription
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Hold Requested")>
        Public ReadOnly Property JobBillHoldRequested() As Boolean
            Get
                JobBillHoldRequested = _ProductionSummary.JobBillHoldRequested
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property BillHoldAmount() As Nullable(Of Decimal)
            Get
                BillHoldAmount = _ProductionSummary.BillHoldAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Approval Comments")>
        Public ReadOnly Property BillingApprovalHeaderComment() As String
            Get
                BillingApprovalHeaderComment = _ProductionSummary.BillingApprovalHeaderComment
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)

            _ProductionSummary = ProductionSummary

        End Sub

#End Region

    End Class

End Namespace