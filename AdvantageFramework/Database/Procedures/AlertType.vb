Namespace Database.Procedures.AlertType

    <HideModuleName()>
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

        Public Function LoadOnlyAlertTypes(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AlertType)

            LoadOnlyAlertTypes = From AlertType In DbContext.AlertTypes
                                 Where AlertType.ID = 6 OrElse AlertType.ID = 7
                                 Select AlertType


        End Function
        Public Function LoadByAlertTypeDescription(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertTypeDescription As String) As Database.Entities.AlertType

            Try

                LoadByAlertTypeDescription = (From AlertType In DbContext.AlertTypes
                                              Where AlertType.Description = AlertTypeDescription
                                              Select AlertType).SingleOrDefault

            Catch ex As Exception
                LoadByAlertTypeDescription = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AlertType)

            Load = From AlertType In DbContext.GetQuery(Of Database.Entities.AlertType)
                   Select AlertType

        End Function

#End Region

    End Module

End Namespace
