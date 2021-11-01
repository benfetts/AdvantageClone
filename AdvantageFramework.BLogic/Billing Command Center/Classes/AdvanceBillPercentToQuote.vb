Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class AdvanceBillPercentToQuote
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PercentToQuote
            ExcludeNonbillableFunctions
        End Enum

#End Region

#Region " Variables "

        Private _PercentToQuote As Decimal = Nothing
        Private _ExcludeNonbillableFunctions As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n3", CustomColumnCaption:="% to Quote", UseMinValue:=True, MinValue:=0, UseMaxValue:=True, MaxValue:=100)>
        Public Property PercentToQuote() As Decimal
            Get
                PercentToQuote = _PercentToQuote
            End Get
            Set(value As Decimal)
                _PercentToQuote = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ExcludeNonbillableFunctions() As Boolean
            Get
                ExcludeNonbillableFunctions = _ExcludeNonbillableFunctions
            End Get
            Set(value As Boolean)
                _ExcludeNonbillableFunctions = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(PercentToQuote As Decimal, ExcludeNonbillableFunctions As Boolean)

            _PercentToQuote = PercentToQuote
            _ExcludeNonbillableFunctions = ExcludeNonbillableFunctions

        End Sub

#End Region

    End Class

End Namespace