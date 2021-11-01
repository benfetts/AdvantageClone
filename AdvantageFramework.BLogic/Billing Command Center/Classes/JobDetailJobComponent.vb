Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class JobDetailJobComponent

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            JobDescription
            ComponentDescription
            IsAdjusted
            ClientName
            DivisionName
            ProductDescription
            OfficeName
            BillingUser
        End Enum

#End Region

#Region " Variables "

        Private _ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property JobNumber() As Integer
            Get
                JobNumber = _ProductionSummary.JobNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp")>
        Public ReadOnly Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _ProductionSummary.ComponentNumber
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
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ComponentDescription() As String
            Get
                ComponentDescription = _ProductionSummary.ComponentDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsAdjusted() As Boolean
            Get
                IsAdjusted = _ProductionSummary.IsAdjusted
            End Get
            Set(value As Boolean)
                _ProductionSummary.IsAdjusted = value
            End Set
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
        Public ReadOnly Property DivisionName() As String
            Get
                DivisionName = _ProductionSummary.DivisionName
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
        Public ReadOnly Property OfficeName() As String
            Get
                OfficeName = _ProductionSummary.OfficeDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ABFlag() As Nullable(Of Short)
            Get
                ABFlag = _ProductionSummary.ABFlag
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BillingUser() As String
            Get
                BillingUser = _ProductionSummary.BillingUser
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