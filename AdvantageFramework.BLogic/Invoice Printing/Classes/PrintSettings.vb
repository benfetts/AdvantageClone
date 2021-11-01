Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class PrintSettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ExportPath
			PackageType
			IncludeAPDocuments
            IncludeExpenseReportReceipts
            IncludeCoverSheet
            SendToDocumentManager
        End Enum

#End Region

#Region " Variables "

        Private _ExportPath As String = ""
		Private _PackageType As AdvantageFramework.InvoicePrinting.PackageTypes = PackageTypes.None
		Private _IncludeAPDocuments As Boolean = False
        Private _IncludeExpenseReportReceipts As Boolean = False
        Private _IncludeCoverSheet As Boolean = False
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
		Public Property PackageType() As AdvantageFramework.InvoicePrinting.PackageTypes
			Get
				PackageType = _PackageType
			End Get
			Set(ByVal value As AdvantageFramework.InvoicePrinting.PackageTypes)
				_PackageType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeAPDocuments() As Boolean
            Get
                IncludeAPDocuments = _IncludeAPDocuments
            End Get
            Set(ByVal value As Boolean)
                _IncludeAPDocuments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeExpenseReportReceipts() As Boolean
            Get
                IncludeExpenseReportReceipts = _IncludeExpenseReportReceipts
            End Get
            Set(ByVal value As Boolean)
                _IncludeExpenseReportReceipts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeCoverSheet() As Boolean
            Get
                IncludeCoverSheet = _IncludeCoverSheet
            End Get
            Set(ByVal value As Boolean)
                _IncludeCoverSheet = value
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
