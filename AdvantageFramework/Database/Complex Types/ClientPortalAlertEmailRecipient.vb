Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="ClientPortalAlertEmailRecipient")>
    <Serializable()>
    Public Class ClientPortalAlertEmailRecipient
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertID
            AlertRecipientID
            CDPContactID
            EmailAddress
            ContactFullName
            MailBeeTitle
        End Enum

#End Region

#Region " Variables "

        Private _AlertID As Integer = Nothing
        Private _AlertRecipientID As Integer = Nothing
        Private _CDPContactID As Integer = Nothing
        Private _EmailAddress As String = Nothing
        Private _ContactFullName As String = Nothing
        Private _MailBeeTitle As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AlertID() As Integer
            Get
                AlertID = _AlertID
            End Get
            Set(value As Integer)
                _AlertID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AlertRecipientID() As Integer
            Get
                AlertRecipientID = _AlertRecipientID
            End Get
            Set(value As Integer)
                _AlertRecipientID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CDPContactID() As Integer
            Get
                CDPContactID = _CDPContactID
            End Get
            Set(value As Integer)
                _CDPContactID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
            Set(value As String)
                _EmailAddress = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContactFullName() As String
            Get
                ContactFullName = _ContactFullName
            End Get
            Set(value As String)
                _ContactFullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MailBeeTitle() As String
            Get
                MailBeeTitle = _MailBeeTitle
            End Get
            Set(value As String)
                _MailBeeTitle = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AlertID.ToString

        End Function

#End Region

    End Class

End Namespace
