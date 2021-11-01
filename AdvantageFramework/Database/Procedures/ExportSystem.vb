Namespace Database.Procedures.ExportSystem

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

        Public Function LoadBySystemName(ByVal DbContext As Database.DbContext, ByVal SystemName As AdvantageFramework.Database.Entities.ExportSystem.SystemNames) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExportSystem)

            Dim SysName As String = Nothing

            SysName = SystemName.ToString

            Try

                LoadBySystemName = From ExportSystem In DbContext.GetQuery(Of Database.Entities.ExportSystem)
                                   Where ExportSystem.SystemName = SysName
                                   Select ExportSystem

            Catch ex As Exception
                LoadBySystemName = Nothing
            End Try


        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExportSystem)

            Load = From ExportSystem In DbContext.GetQuery(Of Database.Entities.ExportSystem)
                   Select ExportSystem

        End Function

#End Region

    End Module

End Namespace
