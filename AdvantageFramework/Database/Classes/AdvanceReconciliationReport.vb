Namespace Database.Classes

    <Serializable()>
    Public Class AdvanceReconciliationReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillingPeriod
            BilledToDate
            ReconciledToDate
            RecognizedToDate
            Balance
            AdvanceResaleTax
            FinalRecAdj
            JobNumber
            JobComponentNumber
        End Enum

#End Region

#Region " Variables "

        Private _BillingPeriod As String = Nothing
        Private _BilledToDate As Nullable(Of Decimal) = Nothing
        Private _ReconciledToDate As Nullable(Of Decimal) = Nothing
        Private _RecognizedToDate As Nullable(Of Decimal) = Nothing
        Private _Balance As Nullable(Of Decimal) = Nothing
        Private _AdvanceResaleTax As Nullable(Of Decimal) = Nothing
        Private _FinalRecAdj As Nullable(Of Decimal) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "


        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingPeriod() As String
            Get
                BillingPeriod = _BillingPeriod
            End Get
            Set(ByVal value As String)
                _BillingPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledToDate() As Nullable(Of Decimal)
            Get
                BilledToDate = _BilledToDate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ReconciledToDate() As Nullable(Of Decimal)
            Get
                ReconciledToDate = _ReconciledToDate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ReconciledToDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property RecognizedToDate() As Nullable(Of Decimal)
            Get
                RecognizedToDate = _RecognizedToDate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RecognizedToDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Balance() As Nullable(Of Decimal)
            Get
                Balance = _Balance
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Balance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceResaleTax() As Nullable(Of Decimal)
            Get
                AdvanceResaleTax = _AdvanceResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AdvanceResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property FinalRecAdj() As Nullable(Of Decimal)
            Get
                FinalRecAdj = _FinalRecAdj
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _FinalRecAdj = value
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
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

    End Class

End Namespace
