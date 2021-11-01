Namespace Database.Procedures.RadioOrderStatus

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

        Public Function LoadByOrderNumberAndLineNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As IQueryable(Of AdvantageFramework.Database.Entities.RadioOrderStatus)

            LoadByOrderNumberAndLineNumber = From RadioOrderStatus In DbContext.GetQuery(Of Database.Entities.RadioOrderStatus).Include("OrderStatus")
                                             Where RadioOrderStatus.OrderNumber = OrderNumber AndAlso
                                                   RadioOrderStatus.LineNumber = LineNumber
                                             Select RadioOrderStatus

        End Function
        Public Function LoadByOrderNumberAndLineNumberRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short) As IQueryable(Of AdvantageFramework.Database.Entities.RadioOrderStatus)

            LoadByOrderNumberAndLineNumberRevision = From RadioOrderStatus In DbContext.GetQuery(Of Database.Entities.RadioOrderStatus).Include("OrderStatus")
                                                     Where RadioOrderStatus.OrderNumber = OrderNumber AndAlso
                                                           RadioOrderStatus.LineNumber = LineNumber AndAlso
                                                           RadioOrderStatus.RevisionNumber = RevisionNumber
                                                     Select RadioOrderStatus

        End Function
        Public Function LoadByOrderNumberLines(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.RadioOrderStatus)

            LoadByOrderNumberLines = From RadioOrderStatus In DbContext.GetQuery(Of Database.Entities.RadioOrderStatus)
                                     Where RadioOrderStatus.OrderNumber = OrderNumber AndAlso
                                           LineNumbers.Contains(RadioOrderStatus.LineNumber)
                                     Select RadioOrderStatus

        End Function
        Public Function LoadByOrderNumber(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.RadioOrderStatus)

            LoadByOrderNumber = From RadioOrderStatus In DbContext.GetQuery(Of Database.Entities.RadioOrderStatus)
                                Where RadioOrderStatus.OrderNumber = OrderNumber
                                Select RadioOrderStatus

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of Entities.RadioOrderStatus)

            Load = DbContext.Set(Of Entities.RadioOrderStatus)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.RadioOrderStatuses.Add(RadioOrderStatus)

                ErrorText = RadioOrderStatus.ValidateEntity(IsValid)

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
