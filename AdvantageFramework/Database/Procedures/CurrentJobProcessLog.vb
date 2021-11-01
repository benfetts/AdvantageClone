Namespace Database.Procedures.CurrentJobProcessLog

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.CurrentJobProcessLog)

            Load = From CurrentJobProcessLog In DbContext.GetQuery(Of Database.Views.CurrentJobProcessLog)
                   Select CurrentJobProcessLog

        End Function
        Public Function LoadByCurrentProcessControl(ByVal DbContext As Database.DbContext, ByVal CurrentProcessControl As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.CurrentJobProcessLog)

            LoadByCurrentProcessControl = From CurrentJobProcessLog In DbContext.GetQuery(Of Database.Views.CurrentJobProcessLog)
                                          Where CurrentJobProcessLog.NewProcessControl = CurrentProcessControl
                                          Select CurrentJobProcessLog

        End Function

#End Region

    End Module

End Namespace
