Namespace Database.Procedures.MagazineView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Magazine)

            Load = From Magazine In DbContext.GetQuery(Of Database.Views.Magazine)
                   Select Magazine

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer) As AdvantageFramework.Database.Views.Magazine

            Try

                LoadByOrderNumber = (From Magazine In DbContext.GetQuery(Of Database.Views.Magazine)
                                     Where Magazine.OrderNumber = OrderNumber
                                     Select Magazine).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
