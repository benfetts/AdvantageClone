Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="TrafficScheduleUserColumn")>
    <Serializable()>
    Public Class TrafficScheduleUserColumn
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ColumnName
            ColumnLongDescription
            ColumnShortDescription
            AgencyRequired
            ClientRequired
            Active
            DefaultShowLongDescription
            ShowLongDescription
            SequenceNumber
            HeaderCode
            ShowOnGrid
            ShowOnAddNew
            ShowFull
            HeaderText
            DisplayType
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _ColumnName As String = Nothing
        Private _ColumnLongDescription As String = Nothing
        Private _ColumnShortDescription As String = Nothing
        Private _AgencyRequired As Byte = Nothing
        Private _ClientRequired As Byte = Nothing
        Private _Active As Byte = Nothing
        Private _DefaultShowLongDescription As Byte = Nothing
        Private _ShowLongDescription As Integer = Nothing
        Private _SequenceNumber As Integer = Nothing
        Private _HeaderCode As String = Nothing
        Private _ShowOnGrid As String = Nothing
        Private _ShowOnAddNew As String = Nothing
        Private _ShowFull As String = Nothing
        Private _HeaderText As String = Nothing
        Private _DisplayType As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ColumnName() As String
            Get
                ColumnName = _ColumnName
            End Get
            Set(value As String)
                _ColumnName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Column Heading")>
        Public Property ColumnShortDescription() As String
            Get
                ColumnShortDescription = _ColumnShortDescription
            End Get
            Set(value As String)
                _ColumnShortDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Description")>
        Public Property ColumnLongDescription() As String
            Get
                ColumnLongDescription = _ColumnLongDescription
            End Get
            Set(value As String)
                _ColumnLongDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AgencyRequired() As Byte
            Get
                AgencyRequired = _AgencyRequired
            End Get
            Set(value As Byte)
                _AgencyRequired = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClientRequired() As Byte
            Get
                ClientRequired = _ClientRequired
            End Get
            Set(value As Byte)
                _ClientRequired = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Active() As Byte
            Get
                Active = _Active
            End Get
            Set(value As Byte)
                _Active = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultShowLongDescription() As Byte
            Get
                DefaultShowLongDescription = _DefaultShowLongDescription
            End Get
            Set(value As Byte)
                _DefaultShowLongDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowLongDescription() As Integer
            Get
                ShowLongDescription = _ShowLongDescription
            End Get
            Set(value As Integer)
                _ShowLongDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Integer
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Integer)
                _SequenceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HeaderCode() As String
            Get
                HeaderCode = _HeaderCode
            End Get
            Set(value As String)
                _HeaderCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, defaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ShowOnGrid() As String
            Get
                ShowOnGrid = _ShowOnGrid
            End Get
            Set(value As String)
                _ShowOnGrid = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowOnAddNew() As String
            Get
                ShowOnAddNew = _ShowOnAddNew
            End Get
            Set(value As String)
                _ShowOnAddNew = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowFull() As String
            Get
                ShowFull = _ShowFull
            End Get
            Set(value As String)
                _ShowFull = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HeaderText() As String
            Get
                HeaderText = _HeaderText
            End Get
            Set(value As String)
                _HeaderText = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DisplayType() As String
            Get
                DisplayType = _DisplayType
            End Get
            Set(value As String)
                _DisplayType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
