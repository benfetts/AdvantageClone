Namespace Database.Procedures.MediaTraffic

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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTraffic)

            Load = From MediaTraffic In DbContext.GetQuery(Of Database.Entities.MediaTraffic)
                   Select MediaTraffic

        End Function

#End Region

    End Module

End Namespace
