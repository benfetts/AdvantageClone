Namespace Database.Procedures.TVOrder

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

        Public Function IsDailyBuy(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Boolean

            If (From TVOrder In DbContext.GetQuery(Of Database.Entities.TVOrder)
                Where TVOrder.OrderNumber = OrderNumber AndAlso
                      TVOrder.Units = "DB"
                Select TVOrder).Any Then

                IsDailyBuy = True

            Else

                IsDailyBuy = False

            End If

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrder)

            LoadByClientCode = From TVOrder In DbContext.GetQuery(Of Database.Entities.TVOrder)
                               Where TVOrder.ClientCode = ClientCode
                               Select TVOrder

        End Function
        Public Function LoadByClientCodeAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrder)

            LoadByClientCodeAndDivisionCode = From TVOrder In DbContext.GetQuery(Of Database.Entities.TVOrder)
                                              Where TVOrder.ClientCode = ClientCode AndAlso
                                                    TVOrder.DivisionCode = DivisionCode
                                              Select TVOrder

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrder)

            LoadByClientAndDivisionAndProductCode = From TVOrder In DbContext.GetQuery(Of Database.Entities.TVOrder)
                                                    Where TVOrder.ClientCode = ClientCode AndAlso
                                                          TVOrder.DivisionCode = DivisionCode AndAlso
                                                          TVOrder.ProductCode = ProductCode
                                                    Select TVOrder

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.TVOrder

            Try

                LoadByOrderNumber = (From TVOrder In DbContext.GetQuery(Of Database.Entities.TVOrder)
                                     Where TVOrder.OrderNumber = OrderNumber
                                     Select TVOrder).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrder)

            Load = From TVOrder In DbContext.GetQuery(Of Database.Entities.TVOrder)
                   Select TVOrder

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TVOrder As AdvantageFramework.Database.Entities.TVOrder) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(TVOrder)

                ErrorText = TVOrder.ValidateEntity(IsValid)

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
