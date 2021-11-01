Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="ExportData")>
    <Serializable()>
    Public Class ExportData
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TableName
            CSVRowData
        End Enum

#End Region

#Region " Variables "

        Private _TableName As String = Nothing
        Private _CSVRowData As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TableName() As String
            Get
                TableName = _TableName
            End Get
            Set(ByVal value As String)
                _TableName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CSVRowData() As String
            Get
                CSVRowData = _CSVRowData
            End Get
            Set(ByVal value As String)
                _CSVRowData = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.TableName

        End Function

#End Region

    End Class

End Namespace
