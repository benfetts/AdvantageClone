Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class UserBatch

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BillingUser
            BatchName
            BillingUserOnly
        End Enum

#End Region

#Region " Variables "

        Private _BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _BillingCommandCenter.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BillingUser() As String
            Get
                BillingUser = _BillingCommandCenter.BillingUser
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BatchName() As String
            Get
                BatchName = _BillingCommandCenter.BatchName
            End Get
            Set(value As String)
                _BillingCommandCenter.BatchName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billing User")>
        Public ReadOnly Property BillingUserOnly() As String
            Get
                BillingUserOnly = Mid(_BillingCommandCenter.BillingUser, 1, _BillingCommandCenter.BillingUser.Length - 2)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter)

            _BillingCommandCenter = BillingCommandCenter

        End Sub

#End Region

    End Class

End Namespace