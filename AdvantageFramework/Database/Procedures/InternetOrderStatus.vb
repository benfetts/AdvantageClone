Namespace Database.Procedures.InternetOrderStatus

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

        Public Function LoadByOrderNumberAndLineNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.InternetOrderStatus)

            LoadByOrderNumberAndLineNumber = From InternetOrderStatus In DbContext.GetQuery(Of Database.Entities.InternetOrderStatus)
                                             Where InternetOrderStatus.OrderNumber = OrderNumber AndAlso
                                                   InternetOrderStatus.LineNumber = LineNumber
                                             Select InternetOrderStatus

        End Function
        Public Function LoadByOrderNumberAndLineNumberRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.InternetOrderStatus)

            LoadByOrderNumberAndLineNumberRevision = From InternetOrderStatus In DbContext.GetQuery(Of Database.Entities.InternetOrderStatus)
                                                     Where InternetOrderStatus.OrderNumber = OrderNumber AndAlso
                                                         InternetOrderStatus.LineNumber = LineNumber AndAlso
                                                         InternetOrderStatus.RevisionNumber = RevisionNumber
                                                     Select InternetOrderStatus

        End Function
        Public Function LoadByOrderNumberLines(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.InternetOrderStatus)

            LoadByOrderNumberLines = From InternetOrderStatus In DbContext.GetQuery(Of Database.Entities.InternetOrderStatus)
                                     Where InternetOrderStatus.OrderNumber = OrderNumber AndAlso
                                           LineNumbers.Contains(InternetOrderStatus.LineNumber)
                                     Select InternetOrderStatus

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Entities.InternetOrderStatus)

            Load = DbContext.Set(Of Entities.InternetOrderStatus)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.InternetOrderStatuses.Add(InternetOrderStatus)

                ErrorText = InternetOrderStatus.ValidateEntity(IsValid)

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
