Namespace Database.Procedures.TVOrderStatus

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

        Public Function LoadByOrderNumberAndLineNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.TVOrderStatus)

            LoadByOrderNumberAndLineNumber = From TVOrderStatus In DbContext.GetQuery(Of Database.Entities.TVOrderStatus).Include("OrderStatus")
                                             Where TVOrderStatus.OrderNumber = OrderNumber AndAlso
                                                   TVOrderStatus.LineNumber = LineNumber
                                             Select TVOrderStatus

        End Function
        Public Function LoadByOrderNumberAndLineNumberRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.TVOrderStatus)

            LoadByOrderNumberAndLineNumberRevision = From TVOrderStatus In DbContext.GetQuery(Of Database.Entities.TVOrderStatus)
                                                     Where TVOrderStatus.OrderNumber = OrderNumber AndAlso
                                                   TVOrderStatus.LineNumber = LineNumber AndAlso
                                                         TVOrderStatus.RevisionNumber = RevisionNumber
                                                     Select TVOrderStatus

        End Function
        Public Function LoadByOrderNumberLines(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.TVOrderStatus)

            LoadByOrderNumberLines = From TVOrderStatus In DbContext.GetQuery(Of Database.Entities.TVOrderStatus)
                                     Where TVOrderStatus.OrderNumber = OrderNumber AndAlso
                                           LineNumbers.Contains(TVOrderStatus.LineNumber)
                                     Select TVOrderStatus

        End Function
        Public Function LoadByOrderNumber(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.TVOrderStatus)

            LoadByOrderNumber = From TVOrderStatus In DbContext.GetQuery(Of Database.Entities.TVOrderStatus)
                                Where TVOrderStatus.OrderNumber = OrderNumber
                                Select TVOrderStatus

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Entities.TVOrderStatus)

            Load = DbContext.Set(Of Entities.TVOrderStatus)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.TVOrderStatuses.Add(TVOrderStatus)

                ErrorText = TVOrderStatus.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
