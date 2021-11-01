Namespace Database.Procedures.NewspaperOrder

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

        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NewspaperOrder)

            LoadByClientCode = From NewspaperOrder In DbContext.GetQuery(Of Database.Entities.NewspaperOrder)
                               Where NewspaperOrder.ClientCode = ClientCode
                               Select NewspaperOrder

        End Function
        Public Function LoadByClientCodeAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NewspaperOrder)

            LoadByClientCodeAndDivisionCode = From NewspaperOrder In DbContext.GetQuery(Of Database.Entities.NewspaperOrder)
                                              Where NewspaperOrder.ClientCode = ClientCode AndAlso
                                                    NewspaperOrder.DivisionCode = DivisionCode
                                              Select NewspaperOrder

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NewspaperOrder)

            LoadByClientAndDivisionAndProductCode = From NewspaperOrder In DbContext.GetQuery(Of Database.Entities.NewspaperOrder)
                                                    Where NewspaperOrder.ClientCode = ClientCode AndAlso
                                                          NewspaperOrder.DivisionCode = DivisionCode AndAlso
                                                          NewspaperOrder.ProductCode = ProductCode
                                                    Select NewspaperOrder

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.NewspaperOrder

            Try

                LoadByOrderNumber = (From NewspaperOrder In DbContext.GetQuery(Of Database.Entities.NewspaperOrder)
                                     Where NewspaperOrder.OrderNumber = OrderNumber
                                     Select NewspaperOrder).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NewspaperOrder)

            Load = From NewspaperOrder In DbContext.GetQuery(Of Database.Entities.NewspaperOrder)
                   Select NewspaperOrder

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(NewspaperOrder)

                ErrorText = NewspaperOrder.ValidateEntity(IsValid)

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
