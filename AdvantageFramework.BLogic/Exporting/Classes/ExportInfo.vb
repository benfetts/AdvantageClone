Namespace Exporting.Classes

    <Serializable()>
    Public Class ExportInfo

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ExportType
        End Enum

#End Region

#Region " Variables "

        Private _ExportType As AdvantageFramework.Exporting.ExportTypes = AdvantageFramework.Exporting.ExportTypes.MediaPlanData

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExportType() As AdvantageFramework.Exporting.ExportTypes
            Get
                ExportType = _ExportType
            End Get
            Set(ByVal value As AdvantageFramework.Exporting.ExportTypes)
                _ExportType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ExportType As AdvantageFramework.Exporting.ExportTypes)

            _ExportType = ExportType

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ExportType.ToString

        End Function

#End Region

    End Class

End Namespace

