Namespace Database.Procedures.TimeRuleLog

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

        Public Function LoadLastTimeLog(ByVal DbContext As Database.DbContext) As Database.Entities.TimeRuleLog

            Try

                LoadLastTimeLog = (From TimeRuleLog In DbContext.GetQuery(Of Database.Entities.TimeRuleLog)
                                   Select TimeRuleLog
                                   Order By TimeRuleLog.ProcessYear Descending,
                                            TimeRuleLog.ProcessMonth Descending).FirstOrDefault

            Catch ex As Exception
                LoadLastTimeLog = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TimeRuleLog)

            Load = From TimeRuleLog In DbContext.GetQuery(Of Database.Entities.TimeRuleLog)
                   Select TimeRuleLog

        End Function

#End Region

    End Module

End Namespace
