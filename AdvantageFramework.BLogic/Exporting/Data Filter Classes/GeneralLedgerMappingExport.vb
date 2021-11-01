Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class GeneralLedgerMappingExport
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            RecordSourceID
        End Enum

#End Region

#Region " Variables "

        Private _RecordSourceID As Integer = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RecordSourceID() As Integer
            Get
                RecordSourceID = _RecordSourceID
            End Get
            Set(value As Integer)
                _RecordSourceID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            If Debugger.IsAttached Then


            Else


            End If

        End Sub
        Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

            'objects
            Dim FilterString As String = ""

            FilterString = String.Format("EXEC dbo.advsp_gl_xref_export_export @RECORD_SOURCE_ID")

            EntityFilterString = FilterString

        End Function
        Public Function Validate(ByRef ErrorMessage As String) As Boolean Implements Interfaces.IExportDataFilter.Validate

            'objects
            Dim IsValid As Boolean = False

            If _RecordSourceID = 0 Then

                ErrorMessage = "Please select a valid record source."

            Else

                IsValid = True

            End If

            Validate = IsValid

        End Function

#End Region

    End Class

End Namespace
