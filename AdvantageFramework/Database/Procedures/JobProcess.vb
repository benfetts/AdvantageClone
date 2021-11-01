Namespace Database.Procedures.JobProcess

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

        Public Function LoadOpen(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.JobProcess)

            LoadOpen = From JobProcess In DataContext.JobProcesses
                       Where JobProcess.ID <> 6 AndAlso
                             JobProcess.ID <> 12
                       Select JobProcess

        End Function
        Public Function LoadMediaProcesses(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.JobProcess)

            LoadMediaProcesses = From JobProcess In DataContext.JobProcesses
                                 Where (JobProcess.ID = 1 OrElse
                                        JobProcess.ID = 6 OrElse
                                        JobProcess.ID = 13)
                                 Select JobProcess

        End Function
        Public Function LoadMediaProcessesOpen(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.JobProcess)

            LoadMediaProcessesOpen = From JobProcess In DataContext.JobProcesses
                                     Where (JobProcess.ID = 1 OrElse
                                            JobProcess.ID = 13)
                                     Select JobProcess

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.JobProcess)

            Load = From JobProcess In DataContext.JobProcesses
                   Select JobProcess

        End Function

#End Region

    End Module

End Namespace
