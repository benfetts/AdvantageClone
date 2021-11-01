Namespace Security.Database.Procedures.UserPerimissionsReportView

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByVal ObjectContext As Database.ObjectContext) As System.Data.Objects.ObjectQuery(Of Security.Database.Views.UserPerimissionsReport)

            Load = From UserPerimissionsReport In ObjectContext.UserPerimissionsReports _
                   Select UserPerimissionsReport

        End Function

#End Region

    End Module

End Namespace
