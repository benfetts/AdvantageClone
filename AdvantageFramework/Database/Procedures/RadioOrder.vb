Namespace Database.Procedures.RadioOrder

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

            If (From RadioOrder In DbContext.GetQuery(Of Database.Entities.RadioOrder)
                Where RadioOrder.OrderNumber = OrderNumber AndAlso
                      RadioOrder.Units = "DB"
                Select RadioOrder).Any Then

                IsDailyBuy = True

            Else

                IsDailyBuy = False

            End If

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrder)

            LoadByClientCode = From RadioOrder In DbContext.GetQuery(Of Database.Entities.RadioOrder)
                               Where RadioOrder.ClientCode = ClientCode
                               Select RadioOrder

        End Function
        Public Function LoadByClientCodeAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrder)

            LoadByClientCodeAndDivisionCode = From RadioOrder In DbContext.GetQuery(Of Database.Entities.RadioOrder)
                                              Where RadioOrder.ClientCode = ClientCode AndAlso
                                                    RadioOrder.DivisionCode = DivisionCode
                                              Select RadioOrder

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrder)

            LoadByClientAndDivisionAndProductCode = From RadioOrder In DbContext.GetQuery(Of Database.Entities.RadioOrder)
                                                    Where RadioOrder.ClientCode = ClientCode AndAlso
                                                          RadioOrder.DivisionCode = DivisionCode AndAlso
                                                          RadioOrder.ProductCode = ProductCode
                                                    Select RadioOrder

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.RadioOrder

            Try

                LoadByOrderNumber = (From RadioOrder In DbContext.GetQuery(Of Database.Entities.RadioOrder)
                                     Where RadioOrder.OrderNumber = OrderNumber
                                     Select RadioOrder).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioOrder)

            Load = From RadioOrder In DbContext.GetQuery(Of Database.Entities.RadioOrder)
                   Select RadioOrder

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RadioOrder As AdvantageFramework.Database.Entities.RadioOrder) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(RadioOrder)

                ErrorText = RadioOrder.ValidateEntity(IsValid)

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
