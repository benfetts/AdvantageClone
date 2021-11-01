Namespace Database.Procedures.CustomNavigationTabItem

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

        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal SequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomNavigationTabItem)

            LoadByUserCode = From CustomNavigationTabItem In DbContext.GetQuery(Of Database.Entities.CustomNavigationTabItem)
                             Where CustomNavigationTabItem.UserCode = UserCode AndAlso
                                   CustomNavigationTabItem.SequenceNumber = SequenceNumber
                             Select CustomNavigationTabItem

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomNavigationTabItem)

            Load = From CustomNavigationTabItem In DbContext.GetQuery(Of Database.Entities.CustomNavigationTabItem)
                   Select CustomNavigationTabItem

        End Function

#End Region

    End Module

End Namespace
