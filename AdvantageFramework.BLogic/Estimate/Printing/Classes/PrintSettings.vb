Namespace Estimate.Classes

    <Serializable()>
    Public Class PrintSettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ExportPath
            PackageType
            SendToDocumentManager
        End Enum

#End Region

#Region " Variables "

        Private _ExportPath As String = ""
        Private _PackageType As AdvantageFramework.Estimate.Printing.PackageTypes = Estimate.Printing.PackageTypes.None
        Private _SendToDocumentManager As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExportPath As String
            Get
                ExportPath = _ExportPath
            End Get
            Set(ByVal value As String)
                _ExportPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PackageType() As AdvantageFramework.Estimate.Printing.PackageTypes
            Get
                PackageType = _PackageType
            End Get
            Set(ByVal value As AdvantageFramework.Estimate.Printing.PackageTypes)
                _PackageType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SendToDocumentManager() As Boolean
            Get
                SendToDocumentManager = _SendToDocumentManager
            End Get
            Set(ByVal value As Boolean)
                _SendToDocumentManager = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ExportPath

        End Function

#End Region

    End Class

End Namespace
