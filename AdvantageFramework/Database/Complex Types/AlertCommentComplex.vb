Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="AlertCommentComplex")>
    <Serializable()>
    Public Class AlertCommentComplex
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CommentID
            Comment
            ShortComment
            IsTruncated
            UserName
            EmployeeCode
            GeneratedDate
            EmployeeFullName
        End Enum

#End Region

#Region " Variables "

        Private _CommentID As Nullable(Of Integer) = Nothing
        Private _Comment As String = Nothing
        Private _ShortComment As String = Nothing
        Private _IsTruncated As Nullable(Of Integer) = Nothing
        Private _UserName As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _GeneratedDate As Nullable(Of Date) = Nothing
        Private _EmployeeFullName As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommentID() As Nullable(Of Integer)
            Get
                CommentID = _CommentID
            End Get
            Set(value As Nullable(Of Integer))
                _CommentID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShortComment() As String
            Get
                ShortComment = _ShortComment
            End Get
            Set(value As String)
                _ShortComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsTruncated() As Nullable(Of Integer)
            Get
                IsTruncated = _IsTruncated
            End Get
            Set(value As Nullable(Of Integer))
                _IsTruncated = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UserName() As String
            Get
                UserName = _UserName
            End Get
            Set(value As String)
                _UserName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
        Public Property GeneratedDate() As Nullable(Of Date)
            Get
                GeneratedDate = _GeneratedDate
            End Get
            Set(value As Nullable(Of Date))
                _GeneratedDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeFullName() As String
            Get
                EmployeeFullName = _EmployeeFullName
            End Get
            Set(value As String)
                _EmployeeFullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.CommentID.ToString

        End Function

#End Region

    End Class

End Namespace
