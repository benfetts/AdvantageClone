Namespace Database.Classes

    <Serializable()>
    Public Class JobTemplateDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SequenceNumber
            ItemCode
            OriginalLabel
            Label
            ItemOrder
            SectionOrder
            IsRequired
            Include
            AdvantageRequired
        End Enum

#End Region

#Region " Variables "

        Private _SequenceNumber As Short = Nothing
        Private _ItemCode As String = Nothing
        Private _OriginalLabel As String = Nothing
        Private _Label As String = Nothing
        Private _ItemOrder As Nullable(Of Short) = Nothing
        Private _SectionOrder As Nullable(Of Short) = Nothing
        Private _IsRequired As Nullable(Of Byte) = Nothing
        Private _Include As Nullable(Of Byte) = Nothing
        Private _AdvantageRequired As Byte = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ItemCode() As String
            Get
                ItemCode = _ItemCode
            End Get
            Set(value As String)
                _ItemCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property OriginalLabel() As String
            Get
                OriginalLabel = _OriginalLabel
            End Get
            Set(value As String)
                _OriginalLabel = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Label() As String
            Get
                Label = _Label
            End Get
            Set(value As String)
                _Label = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SectionOrder() As Nullable(Of Short)
            Get
                SectionOrder = _SectionOrder
            End Get
            Set(value As Nullable(Of Short))
                _SectionOrder = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ItemOrder() As Nullable(Of Short)
            Get
                ItemOrder = _ItemOrder
            End Get
            Set(value As Nullable(Of Short))
                _ItemOrder = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="On", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property Include() As Nullable(Of Byte)
            Get
                Include = _Include
            End Get
            Set(value As Nullable(Of Byte))
                _Include = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AdvantageRequired() As Byte
            Get
                AdvantageRequired = _AdvantageRequired
            End Get
            Set(value As Byte)
                _AdvantageRequired = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Required", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsRequired() As Nullable(Of Byte)
            Get
                IsRequired = _IsRequired
            End Get
            Set(value As Nullable(Of Byte))
                _IsRequired = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal JobTemplateDetail As AdvantageFramework.Database.Entities.JobTemplateDetail)

            _ItemCode = JobTemplateDetail.ItemCode
            _Label = JobTemplateDetail.Label
            _ItemOrder = JobTemplateDetail.ItemOrder
            _SectionOrder = JobTemplateDetail.SectionOrder
            _Include = JobTemplateDetail.Include
            _IsRequired = JobTemplateDetail.IsRequired
            _SequenceNumber = JobTemplateDetail.SequenceNumber

            If JobTemplateDetail.JobTemplateItem IsNot Nothing Then

                _OriginalLabel = JobTemplateDetail.JobTemplateItem.Description
                _AdvantageRequired = JobTemplateDetail.JobTemplateItem.AdvantageRequired

            Else

                _AdvantageRequired = CByte(0)

            End If

        End Sub
        Public Function GetJobTemplateDetail() As AdvantageFramework.Database.Entities.JobTemplateDetail

            'objects
            Dim JobTemplateDetail As AdvantageFramework.Database.Entities.JobTemplateDetail = Nothing

            JobTemplateDetail = New AdvantageFramework.Database.Entities.JobTemplateDetail

            JobTemplateDetail.ItemCode = _ItemCode
            JobTemplateDetail.Label = _Label
            JobTemplateDetail.SectionOrder = _SectionOrder

            If _ItemCode = "SECTION" Then

                JobTemplateDetail.Include = CByte(1)
                JobTemplateDetail.IsRequired = CByte(0)

            Else

                JobTemplateDetail.IsRequired = CByte(_IsRequired.GetValueOrDefault(0))
                JobTemplateDetail.Include = CByte(_Include.GetValueOrDefault(0))

            End If
            
            JobTemplateDetail.SequenceNumber = _SequenceNumber

            GetJobTemplateDetail = JobTemplateDetail

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.ItemCode

        End Function

#End Region

    End Class

End Namespace

