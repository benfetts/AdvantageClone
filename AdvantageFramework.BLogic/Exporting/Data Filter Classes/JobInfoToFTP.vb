Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class JobInfoToFTP
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = "JobInfoToFTP"

        End Function
        Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

            'objects
            Dim FilterString As String = ""

            FilterString = "EXEC dbo.advsp_exporting_load_job_info_for_ftp"

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
