Namespace Database.Procedures.InternetOrder

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

        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetOrder)

            LoadByClientCode = From InternetOrder In DbContext.GetQuery(Of Database.Entities.InternetOrder)
                               Where InternetOrder.ClientCode = ClientCode
                               Select InternetOrder

        End Function
        Public Function LoadByClientCodeAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetOrder)

            LoadByClientCodeAndDivisionCode = From InternetOrder In DbContext.GetQuery(Of Database.Entities.InternetOrder)
                                              Where InternetOrder.ClientCode = ClientCode AndAlso
                                                    InternetOrder.DivisionCode = DivisionCode
                                              Select InternetOrder

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetOrder)

            LoadByClientAndDivisionAndProductCode = From InternetOrder In DbContext.GetQuery(Of Database.Entities.InternetOrder)
                                                    Where InternetOrder.ClientCode = ClientCode AndAlso
                                                          InternetOrder.DivisionCode = DivisionCode AndAlso
                                                          InternetOrder.ProductCode = ProductCode
                                                    Select InternetOrder

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.InternetOrder

            Try

                LoadByOrderNumber = (From InternetOrder In DbContext.GetQuery(Of Database.Entities.InternetOrder)
                                     Where InternetOrder.OrderNumber = OrderNumber
                                     Select InternetOrder).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetOrder)

            Load = From InternetOrder In DbContext.GetQuery(Of Database.Entities.InternetOrder)
                   Select InternetOrder

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InternetOrder As AdvantageFramework.Database.Entities.InternetOrder) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(InternetOrder)

                ErrorText = InternetOrder.ValidateEntity(IsValid)

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
