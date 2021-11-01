Namespace Database.Procedures.InternetPackageDetail

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

        Public Function LoadByOrderLineActiveRevision(DbContext As Database.DbContext, OrderNumber As Integer, LineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetPackageDetail)

            LoadByOrderLineActiveRevision = From InternetPackageDetail In DbContext.GetQuery(Of Database.Entities.InternetPackageDetail)
                                            Where InternetPackageDetail.OrderNumber = OrderNumber AndAlso
                                                  InternetPackageDetail.LineNumber = LineNumber AndAlso
                                                  InternetPackageDetail.IsActiveRevision = True
                                            Select InternetPackageDetail

        End Function
        Public Function LoadActiveRevisionsByOrderLines(DbContext As Database.DbContext, OrderNumber As Integer, LineNumbers As IEnumerable(Of Short)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetPackageDetail)

            LoadActiveRevisionsByOrderLines = From InternetPackageDetail In DbContext.GetQuery(Of Database.Entities.InternetPackageDetail)
                                              Where InternetPackageDetail.OrderNumber = OrderNumber AndAlso
                                                    LineNumbers.Contains(InternetPackageDetail.LineNumber) AndAlso
                                                    InternetPackageDetail.IsActiveRevision = True
                                              Select InternetPackageDetail

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetPackageDetail)

            Load = From InternetPackageDetail In DbContext.GetQuery(Of Database.Entities.InternetPackageDetail)
                   Select InternetPackageDetail

        End Function
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, InternetPackageDetail As AdvantageFramework.Database.Entities.InternetPackageDetail, ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(InternetPackageDetail)

                ErrorText = InternetPackageDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
                ErrorText = ex.Message
            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
