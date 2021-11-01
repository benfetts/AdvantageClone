Namespace Database.Procedures.MagazineOrder

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

        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MagazineOrder)

            LoadByClientCode = From MagazineOrder In DbContext.GetQuery(Of Database.Entities.MagazineOrder)
                               Where MagazineOrder.ClientCode = ClientCode
                               Select MagazineOrder

        End Function
        Public Function LoadByClientCodeAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MagazineOrder)

            LoadByClientCodeAndDivisionCode = From MagazineOrder In DbContext.GetQuery(Of Database.Entities.MagazineOrder)
                                              Where MagazineOrder.ClientCode = ClientCode AndAlso
                                                    MagazineOrder.DivisionCode = DivisionCode
                                              Select MagazineOrder

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MagazineOrder)

            LoadByClientAndDivisionAndProductCode = From MagazineOrder In DbContext.GetQuery(Of Database.Entities.MagazineOrder)
                                                    Where MagazineOrder.ClientCode = ClientCode AndAlso
                                                          MagazineOrder.DivisionCode = DivisionCode AndAlso
                                                          MagazineOrder.ProductCode = ProductCode
                                                    Select MagazineOrder

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.MagazineOrder

            Try

                LoadByOrderNumber = (From MagazineOrder In DbContext.GetQuery(Of Database.Entities.MagazineOrder)
                                     Where MagazineOrder.OrderNumber = OrderNumber
                                     Select MagazineOrder).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MagazineOrder)

            Load = From MagazineOrder In DbContext.GetQuery(Of Database.Entities.MagazineOrder)
                   Select MagazineOrder

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MagazineOrder)

                ErrorText = MagazineOrder.ValidateEntity(IsValid)

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
