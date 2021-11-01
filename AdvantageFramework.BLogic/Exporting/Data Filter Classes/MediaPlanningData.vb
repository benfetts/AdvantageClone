Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class MediaPlanningData
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PlanID
            EstimateID
        End Enum

#End Region

#Region " Variables "

        Private _PlanID As Integer = Nothing
        Private _EstimateID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.MediaPlanID)>
        Public Property PlanID() As Integer
            Get
                PlanID = _PlanID
            End Get
            Set(value As Integer)
                _PlanID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.MediaPlanDetailID)>
        Public Property EstimateID() As Nullable(Of Integer)
            Get
                EstimateID = _EstimateID
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _PlanID = 0
            _EstimateID = Nothing

        End Sub
        Public Sub New(ByVal PlanID As Integer, ByVal EstimateID As Nullable(Of Integer))

            Me.PlanID = PlanID
            Me.EstimateID = EstimateID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.PlanID & " - " & Me.EstimateID.GetValueOrDefault(0)

        End Function
        Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

            'objects
            Dim FilterString As String = ""

            If Me.EstimateID.HasValue Then

                FilterString = String.Format("EXEC dbo.advsp_mediaplan_exportdata {0}, {1}", Me.PlanID, Me.EstimateID)

            Else

                FilterString = String.Format("EXEC dbo.advsp_mediaplan_exportdata {0}", Me.PlanID)

            End If

            EntityFilterString = FilterString

        End Function
        Public Function Validate(ByRef ErrorMessage As String) As Boolean Implements Interfaces.IExportDataFilter.Validate

            'objects
            Dim IsValid As Boolean = True

            Validate = IsValid

        End Function

#End Region

    End Class

End Namespace
