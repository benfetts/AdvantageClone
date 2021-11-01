Namespace Database.Procedures.OutOfHomeOrder

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

        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OutOfHomeOrder)

            LoadByClientCode = From OutOfHomeOrder In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrder)
                               Where OutOfHomeOrder.ClientCode = ClientCode
                               Select OutOfHomeOrder

        End Function
        Public Function LoadByClientCodeAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OutOfHomeOrder)

            LoadByClientCodeAndDivisionCode = From OutOfHomeOrder In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrder)
                                              Where OutOfHomeOrder.ClientCode = ClientCode AndAlso
                                                    OutOfHomeOrder.DivisionCode = DivisionCode
                                              Select OutOfHomeOrder

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OutOfHomeOrder)

            LoadByClientAndDivisionAndProductCode = From OutOfHomeOrder In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrder)
                                                    Where OutOfHomeOrder.ClientCode = ClientCode AndAlso
                                                          OutOfHomeOrder.DivisionCode = DivisionCode AndAlso
                                                          OutOfHomeOrder.ProductCode = ProductCode
                                                    Select OutOfHomeOrder

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.OutOfHomeOrder

            Try

                LoadByOrderNumber = (From OutOfHomeOrder In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrder)
                                     Where OutOfHomeOrder.OrderNumber = OrderNumber
                                     Select OutOfHomeOrder).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OutOfHomeOrder)

            Load = From OutOfHomeOrder In DbContext.GetQuery(Of Database.Entities.OutOfHomeOrder)
                   Select OutOfHomeOrder

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OutOfHomeOrder)

                ErrorText = OutOfHomeOrder.ValidateEntity(IsValid)

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
