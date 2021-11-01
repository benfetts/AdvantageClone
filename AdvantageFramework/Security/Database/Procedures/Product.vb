Namespace Security.Database.Procedures.Product

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

        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Security.Database.Entities.Product

            Try

                LoadByClientAndDivisionAndProductCode = (From Product In DbContext.GetQuery(Of Database.Entities.Product)
                                                         Where Product.Code = ProductCode AndAlso
                                                               Product.DivisionCode = DivisionCode AndAlso
                                                               Product.ClientCode = ClientCode
                                                         Select Product).SingleOrDefault

            Catch ex As Exception
                LoadByClientAndDivisionAndProductCode = Nothing
            End Try

        End Function
        Public Function LoaddByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Product)

            LoaddByClientCode = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                                Where Product.ClientCode = ClientCode
                                Select Product

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Product)

            LoadAllActive = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                            Where Product.IsActive = 1
                            Select Product

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Product)

            Load = From Product In DbContext.GetQuery(Of Database.Entities.Product)
                   Select Product

        End Function

#End Region

    End Module

End Namespace
