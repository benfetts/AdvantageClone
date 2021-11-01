Namespace Exporting.Classes

    <Serializable()>
    Public Class ExportField
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FieldName
            Position
            Start
            Length
            [End]
            PreDefinedLength
        End Enum

#End Region

#Region " Variables "

        Private _ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing
        Private _PreDefinedLength As Integer = 0

#End Region

#Region " Properties "

        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()> _
        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.ExportTemplateDetail)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public ReadOnly Property FieldName() As String
            Get
                FieldName = _ExportTemplateDetail.FieldName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Position() As Integer
            Get
                Position = _ExportTemplateDetail.Position
            End Get
            Set(ByVal value As Integer)
                _ExportTemplateDetail.Position = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(UseMinValue:=True, MinValue:=1)>
        Public Property Start() As Nullable(Of Integer)
            Get
                Start = _ExportTemplateDetail.Start
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ExportTemplateDetail.Start = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(UseMinValue:=True, MinValue:=1)>
        Public Property Length() As Nullable(Of Integer)
            Get
                Length = _ExportTemplateDetail.Length
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ExportTemplateDetail.Length = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property [End]() As Integer
            Get
                [End] = _ExportTemplateDetail.Start.GetValueOrDefault(0) + (_ExportTemplateDetail.Length.GetValueOrDefault(0) - 1)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property PreDefinedLength() As String
            Get
                PreDefinedLength = _PreDefinedLength
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ExportTemplateDetail = New AdvantageFramework.Database.Entities.ExportTemplateDetail

        End Sub
        Public Sub New(ByVal AvailableField As AdvantageFramework.Exporting.Classes.AvailableField)

            Me.New()

            _ExportTemplateDetail.FieldName = AvailableField.FieldName
            _PreDefinedLength = AvailableField.PreDefinedLength

            Me.Length = _PreDefinedLength

        End Sub
        Public Sub New(ByVal ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            _ExportTemplateDetail = ExportTemplateDetail

            _PreDefinedLength = AdvantageFramework.Exporting.LoadPreDefinedLength(PropertyDescriptor)

            If Me.Length.HasValue = False Then

                Me.Length = _PreDefinedLength

            End If

        End Sub
        Public Sub New(ByVal FieldName As String, ByVal Position As Integer)

            Me.New()

            _ExportTemplateDetail.FieldName = FieldName
            _ExportTemplateDetail.Position = Position

        End Sub
        Public Overrides Function IsEntityBeingAdded() As Boolean

            IsEntityBeingAdded = _ExportTemplateDetail.IsEntityBeingAdded()

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.FieldName

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ExportTemplateDetail

            GetEntity = _ExportTemplateDetail

        End Function
        Public Sub SetPropertyError(ByVal PropertyName As String, ByVal ErrorText As String)

            _ErrorHashtable(PropertyName) = ErrorText

        End Sub
        Public Function LoadEntityError() As String

            _EntityError = ""

            For Each PropertyErrorText In _ErrorHashtable.Values.OfType(Of String).ToList

                If String.IsNullOrEmpty(PropertyErrorText) = False Then

                    _EntityError = IIf(_EntityError = "", PropertyErrorText, _EntityError & Environment.NewLine & PropertyErrorText)

                End If
                
            Next

            LoadEntityError = _EntityError

        End Function

#End Region

    End Class

End Namespace

