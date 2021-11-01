Namespace Database.Classes

    <Serializable()>
    Public Class ResourceTask

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ResourceCode
            Resource
            TaskCode
            HoursAllowed
            SetHours
            BeforeAfter
            Condition
        End Enum

#End Region

#Region " Variables "

        Private _ResourceTask As AdvantageFramework.Database.Entities.ResourceTask = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID As Integer
            Get
                ID = _ResourceTask.ID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ResourceCode As String
            Get
                ResourceCode = _ResourceTask.ResourceCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property Resource As String
            Get
                Resource = _ResourceTask.Resource.ToString & vbTab & "  Type: " & _ResourceTask.Resource.ResourceType.ToString & vbTab & "  Priority: " & _ResourceTask.Resource.Priority.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property TaskCode() As String
            Get
                TaskCode = _ResourceTask.TaskCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="#0.#0")>
        Public ReadOnly Property HoursAllowed() As Nullable(Of Decimal)
            Get
                HoursAllowed = _ResourceTask.HoursAllowed
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="#0.#0")>
        Public ReadOnly Property SetHours() As Nullable(Of Decimal)
            Get
                SetHours = _ResourceTask.SetHours
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Before / After")>
        Public ReadOnly Property BeforeAfter() As Nullable(Of Short)
            Get
                BeforeAfter = _ResourceTask.BeforeAfter
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Condition() As Nullable(Of Short)
            Get
                Condition = _ResourceTask.Condition
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ResourceTask As AdvantageFramework.Database.Entities.ResourceTask)

            _ResourceTask = ResourceTask

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Function GetResourceTask() As AdvantageFramework.Database.Entities.ResourceTask

            GetResourceTask = _ResourceTask

        End Function

#End Region

    End Class

End Namespace

