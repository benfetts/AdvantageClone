Namespace Database.Procedures.CustomNavigationTab

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

        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomNavigationTab)

            LoadByUserCode = From CustomNavigationTab In DbContext.GetQuery(Of Database.Entities.CustomNavigationTab)
                             Where CustomNavigationTab.UserCode = UserCode
                             Select CustomNavigationTab
                             Order By CustomNavigationTab.SequenceNumber

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CustomNavigationTab)

            Load = From CustomNavigationTab In DbContext.GetQuery(Of Database.Entities.CustomNavigationTab)
                   Select CustomNavigationTab

        End Function

#End Region

    End Module

End Namespace
