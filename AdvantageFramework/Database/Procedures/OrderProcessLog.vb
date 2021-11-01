Namespace Database.Procedures.OrderProcessLog

    <HideModuleName()>
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

        Public Function LoadLatestByOrderNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer) As AdvantageFramework.Database.Entities.OrderProcessLog

            LoadLatestByOrderNumber = (From OrderProcessLog In Load(DbContext)
                                       Order By OrderProcessLog.ProcessedDate Descending, OrderProcessLog.ID Descending
                                       Select OrderProcessLog).FirstOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.OrderProcessLog)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.OrderProcessLog)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderProcessLog As AdvantageFramework.Database.Entities.OrderProcessLog, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.OrderProcessLogs.Add(OrderProcessLog)

                ErrorMessage = OrderProcessLog.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
