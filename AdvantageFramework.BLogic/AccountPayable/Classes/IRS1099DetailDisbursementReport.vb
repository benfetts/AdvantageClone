Namespace AccountPayable.Classes

    <Serializable()>
    Public Class IRS1099DetailDisbursementReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DetailGLAccount
            DisbursedAmount
        End Enum

#End Region

#Region " Variables "

        Private _DetailGLAccount As String = Nothing
        Private _DisbursedAmount As Decimal = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailGLAccount() As String
            Get
                DetailGLAccount = _DetailGLAccount
            End Get
            Set(ByVal value As String)
                _DetailGLAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DisbursedAmount() As Decimal
            Get
                DisbursedAmount = _DisbursedAmount
            End Get
            Set(ByVal value As Decimal)
                _DisbursedAmount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace