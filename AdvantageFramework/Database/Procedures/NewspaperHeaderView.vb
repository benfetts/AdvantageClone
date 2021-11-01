Namespace Database.Procedures.NewspaperHeaderView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.NewspaperHeader)

            Load = From NewspaperHeader In DbContext.GetQuery(Of Database.Views.NewspaperHeader)
                   Select NewspaperHeader

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer) As AdvantageFramework.Database.Views.NewspaperHeader

            Try

                LoadByOrderNumber = (From NewspaperHeader In DbContext.GetQuery(Of Database.Views.NewspaperHeader)
                                     Where NewspaperHeader.OrderNumber = OrderNumber
                                     Select NewspaperHeader).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
