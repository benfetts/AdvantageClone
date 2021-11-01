Namespace Database.Procedures.ExternalGLIFace

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExternalGLIFace)

            Load = From ExternalGLIFace In DbContext.GetQuery(Of Database.Entities.ExternalGLIFace)
                   Select ExternalGLIFace

        End Function
        Public Function GetMaxTransNum(ByVal DbContext As AdvantageFramework.Database.DbContext) As Decimal

            Try

                GetMaxTransNum = (From ExternalGLIFace In DbContext.GetQuery(Of Database.Entities.ExternalGLIFace)
                                  Select ExternalGLIFace.TransNum).Max

            Catch ex As Exception
                GetMaxTransNum = 0
            End Try

        End Function

#End Region

    End Module

End Namespace
