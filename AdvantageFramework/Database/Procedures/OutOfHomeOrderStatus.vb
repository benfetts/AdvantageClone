Namespace Database.Procedures.OutOfHomeOrderStatus

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

        Public Function LoadByOrderNumberAndLineNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.OutOfHomeOrderStatus)

            LoadByOrderNumberAndLineNumber = From OutOfHomeOrderStatus In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrderStatus)
                                             Where OutOfHomeOrderStatus.OrderNumber = OrderNumber AndAlso
                                                   OutOfHomeOrderStatus.LineNumber = LineNumber
                                             Select OutOfHomeOrderStatus

        End Function
        Public Function LoadByOrderNumberAndLineNumberRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.OutOfHomeOrderStatus)

            LoadByOrderNumberAndLineNumberRevision = From OutOfHomeOrderStatus In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrderStatus)
                                                     Where OutOfHomeOrderStatus.OrderNumber = OrderNumber AndAlso
                                                           OutOfHomeOrderStatus.LineNumber = LineNumber AndAlso
                                                           OutOfHomeOrderStatus.RevisionNumber = RevisionNumber
                                                     Select OutOfHomeOrderStatus

        End Function
        Public Function LoadByOrderNumberLines(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.OutOfHomeOrderStatus)

            LoadByOrderNumberLines = From OutOfHomeOrderStatus In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrderStatus)
                                     Where OutOfHomeOrderStatus.OrderNumber = OrderNumber AndAlso
                                           LineNumbers.Contains(OutOfHomeOrderStatus.LineNumber)
                                     Select OutOfHomeOrderStatus

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Entities.OutOfHomeOrderStatus)

            Load = DbContext.Set(Of Entities.OutOfHomeOrderStatus)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OutOfHomeOrderStatuses.Add(OutOfHomeOrderStatus)

                ErrorText = OutOfHomeOrderStatus.ValidateEntity(IsValid)

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
