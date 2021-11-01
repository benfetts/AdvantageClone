Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="AlertEmailRecipient")>
    <Serializable()>
    Public Class AlertEmailRecipient
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            RecipientAlertID
            RecipientID
            RecipientEmployeeCode
            RecipientEmailAddress
            RecipientEmployeeName
            EmployeeCode
            EmployeeEmail
            MailBeeTitle
        End Enum

#End Region

#Region " Variables "

        Private _RecipientAlertID As Integer = Nothing
        Private _RecipientID As Integer = Nothing
        Private _RecipientEmployeeCode As String = Nothing
        Private _RecipientEmailAddress As String = Nothing
        Private _RecipientEmployeeName As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeEmail As String = Nothing
        Private _MailBeeTitle As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecipientAlertID() As Integer
            Get
                RecipientAlertID = _RecipientAlertID
            End Get
            Set(value As Integer)
                _RecipientAlertID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecipientID() As Integer
            Get
                RecipientID = _RecipientID
            End Get
            Set(value As Integer)
                _RecipientID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecipientEmployeeCode() As String
            Get
                RecipientEmployeeCode = _RecipientEmployeeCode
            End Get
            Set(value As String)
                _RecipientEmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecipientEmailAddress() As String
            Get
                RecipientEmailAddress = _RecipientEmailAddress
            End Get
            Set(value As String)
                _RecipientEmailAddress = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecipientEmployeeName() As String
            Get
                RecipientEmployeeName = _RecipientEmployeeName
            End Get
            Set(value As String)
                _RecipientEmployeeName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeEmail() As String
            Get
                EmployeeEmail = _EmployeeEmail
            End Get
            Set(value As String)
                _EmployeeEmail = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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

            ToString = Me.RecipientAlertID.ToString

        End Function

#End Region

    End Class

End Namespace
