Namespace Database.Procedures.NewspaperOrderStatus

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

        Public Function LoadByOrderNumberAndLineNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.NewspaperOrderStatus)

            LoadByOrderNumberAndLineNumber = From NewspaperOrderStatus In DbContext.GetQuery(Of Database.Entities.NewspaperOrderStatus)
                                             Where NewspaperOrderStatus.OrderNumber = OrderNumber AndAlso
                                                   NewspaperOrderStatus.LineNumber = LineNumber
                                             Select NewspaperOrderStatus

        End Function
        Public Function LoadByOrderNumberAndLineNumberRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.NewspaperOrderStatus)

            LoadByOrderNumberAndLineNumberRevision = From NewspaperOrderStatus In DbContext.GetQuery(Of Database.Entities.NewspaperOrderStatus)
                                                     Where NewspaperOrderStatus.OrderNumber = OrderNumber AndAlso
                                                           NewspaperOrderStatus.LineNumber = LineNumber AndAlso
                                                           NewspaperOrderStatus.RevisionNumber = RevisionNumber
                                                     Select NewspaperOrderStatus

        End Function
        Public Function LoadByOrderNumberLines(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.NewspaperOrderStatus)

            LoadByOrderNumberLines = From NewspaperOrderStatus In DbContext.GetQuery(Of Database.Entities.NewspaperOrderStatus)
                                     Where NewspaperOrderStatus.OrderNumber = OrderNumber AndAlso
                                           LineNumbers.Contains(NewspaperOrderStatus.LineNumber)
                                     Select NewspaperOrderStatus

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Entities.NewspaperOrderStatus)

            Load = DbContext.Set(Of Entities.NewspaperOrderStatus)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.NewspaperOrderStatuses.Add(NewspaperOrderStatus)

                ErrorText = NewspaperOrderStatus.ValidateEntity(IsValid)

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
