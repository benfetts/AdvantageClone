Namespace Database.Classes

    <Serializable()>
    Public Class JobSpecificationField
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Name
            JobSpecificationTypeCode
            Description
            FieldDataType
            JobSpecificationCategoryID
            SequenceNumber
            IsInactive
            IsRequired
            SeparatorLine
        End Enum

#End Region

#Region " Variables "

        Private _Name As String = Nothing
        Private _JobSpecificationTypeCode As String = Nothing
        Private _Description As String = Nothing
        Private _FieldDataType As String = Nothing
        Private _JobSpecificationCategoryID As Integer = Nothing
        Private _SequenceNumber As Integer = Nothing
        Private _IsInactive As Short = Nothing
        Private _IsRequired As Short = Nothing
        Private _SeparatorLine As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobSpecificationTypeCode() As String
            Get
                JobSpecificationTypeCode = _JobSpecificationTypeCode
            End Get
            Set(value As String)
                _JobSpecificationTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Field Label")>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property JobSpecificationCategoryID() As Integer
            Get
                JobSpecificationCategoryID = _JobSpecificationCategoryID
            End Get
            Set(value As Integer)
                _JobSpecificationCategoryID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Integer
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Integer)
                _SequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="On", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
        Public Property IsInactive() As Short
            Get
                IsInactive = _IsInactive
            End Get
            Set(value As Short)
                _IsInactive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsRequired() As Short
            Get
                IsRequired = _IsRequired
            End Get
            Set(value As Short)
                _IsRequired = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FieldDataType() As String
            Get
                FieldDataType = _FieldDataType
            End Get
            Set(value As String)
                _FieldDataType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property SeparatorLine() As Nullable(Of Short)
            Get
                SeparatorLine = _SeparatorLine
            End Get
            Set(value As Nullable(Of Short))
                _SeparatorLine = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(ByVal JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField, ByVal FieldDataType As String)

            _Name = JobSpecificationField.Name
            _JobSpecificationTypeCode = JobSpecificationField.JobSpecificationTypeCode
            _Description = JobSpecificationField.Description
            _FieldDataType = FieldDataType
            _JobSpecificationCategoryID = JobSpecificationField.JobSpecificationCategoryID
            _SequenceNumber = JobSpecificationField.SequenceNumber
            _IsInactive = JobSpecificationField.IsInactive
            _IsRequired = JobSpecificationField.IsRequired
            _SeparatorLine = JobSpecificationField.SeparatorLine

        End Sub

#End Region

    End Class

End Namespace

