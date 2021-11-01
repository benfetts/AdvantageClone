Namespace Database.Procedures.MagazineOrderStatus

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

        Public Function LoadByOrderNumberAndLineNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MagazineOrderStatus)

            LoadByOrderNumberAndLineNumber = From MagazineOrderStatus In DbContext.GetQuery(Of Database.Entities.MagazineOrderStatus)
                                             Where MagazineOrderStatus.OrderNumber = OrderNumber AndAlso
                                                   MagazineOrderStatus.LineNumber = LineNumber
                                             Select MagazineOrderStatus

        End Function
        Public Function LoadByOrderNumberAndLineNumberRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumber As Short, ByVal RevisionNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MagazineOrderStatus)

            LoadByOrderNumberAndLineNumberRevision = From MagazineOrderStatus In DbContext.GetQuery(Of Database.Entities.MagazineOrderStatus)
                                                     Where MagazineOrderStatus.OrderNumber = OrderNumber AndAlso
                                                           MagazineOrderStatus.LineNumber = LineNumber AndAlso
                                                           MagazineOrderStatus.RevisionNumber = RevisionNumber
                                                     Select MagazineOrderStatus

        End Function
        Public Function LoadByOrderNumberLines(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MagazineOrderStatus)

            LoadByOrderNumberLines = From MagazineOrderStatus In DbContext.GetQuery(Of Database.Entities.MagazineOrderStatus)
                                     Where MagazineOrderStatus.OrderNumber = OrderNumber AndAlso
                                           LineNumbers.Contains(MagazineOrderStatus.LineNumber)
                                     Select MagazineOrderStatus

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Entities.MagazineOrderStatus)

            Load = DbContext.Set(Of Entities.MagazineOrderStatus)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MagazineOrderStatuses.Add(MagazineOrderStatus)

                ErrorText = MagazineOrderStatus.ValidateEntity(IsValid)

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
