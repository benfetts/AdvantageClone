Namespace Security.Database.Procedures.EmployeeSummaryView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.EmployeeSummary)

            Load = From EmployeeSummary In DbContext.GetQuery(Of Database.Views.EmployeeSummary)
                   Select EmployeeSummary

        End Function

#End Region

    End Module

End Namespace
