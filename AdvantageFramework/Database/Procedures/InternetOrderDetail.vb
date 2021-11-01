Namespace Database.Procedures.InternetOrderDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetOrderDetail)

            Load = From InternetOrderDetail In DbContext.GetQuery(Of Database.Entities.InternetOrderDetail)
                   Select InternetOrderDetail

        End Function
        Public Function LoadNonCancelledNonCommissionByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetOrderDetail)

            LoadNonCancelledNonCommissionByOrderNumber = From InternetOrderDetail In DbContext.GetQuery(Of Database.Entities.InternetOrderDetail)
                                                         Where InternetOrderDetail.InternetOrderOrderNumber = OrderNumber AndAlso
                                                               InternetOrderDetail.IsActiveRevision = 1 AndAlso
                                                               InternetOrderDetail.BillTypeFlag <> 1 AndAlso
                                                               (InternetOrderDetail.IsLineCancelled Is Nothing OrElse
                                                                InternetOrderDetail.IsLineCancelled = 0)
                                                         Select InternetOrderDetail

        End Function
        Public Function LoadActiveByOrderNumberLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As Database.Entities.InternetOrderDetail

            Try

                LoadActiveByOrderNumberLineNumber = (From InternetOrderDetail In DbContext.GetQuery(Of Database.Entities.InternetOrderDetail)
                                                     Where InternetOrderDetail.InternetOrderOrderNumber = OrderNumber AndAlso
                                                           InternetOrderDetail.LineNumber = LineNumber AndAlso
                                                           InternetOrderDetail.IsActiveRevision = 1
                                                     Select InternetOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadActiveByOrderNumberLineNumber = Nothing
            End Try

        End Function
        Public Function LoadByAllPrimaryKeys(ByVal DbContext As Database.DbContext,
                                             ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short, ByVal SequenceNumber As Short) As Database.Entities.InternetOrderDetail

            Try

                LoadByAllPrimaryKeys = (From InternetOrderDetail In DbContext.GetQuery(Of Database.Entities.InternetOrderDetail)
                                        Where InternetOrderDetail.InternetOrderOrderNumber = OrderNumber AndAlso
                                              InternetOrderDetail.LineNumber = LineNumber AndAlso
                                              InternetOrderDetail.RevisionNumber = RevisionNumber AndAlso
                                              InternetOrderDetail.SequenceNumber = SequenceNumber
                                        Select InternetOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadByAllPrimaryKeys = Nothing
            End Try

        End Function
        Public Function LoadActiveByOrderNumberPackageName(DbContext As Database.DbContext, OrderNumber As Integer, PackageName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetOrderDetail)

            LoadActiveByOrderNumberPackageName = (From InternetOrderDetail In DbContext.GetQuery(Of Database.Entities.InternetOrderDetail)
                                                  Where InternetOrderDetail.InternetOrderOrderNumber = OrderNumber AndAlso
                                                        InternetOrderDetail.Placement2 = PackageName AndAlso
                                                        InternetOrderDetail.IsActiveRevision = 1
                                                  Select InternetOrderDetail)

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(InternetOrderDetail)

                ErrorText = InternetOrderDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
