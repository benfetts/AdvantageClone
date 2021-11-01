Namespace Database.Procedures.MediaBuyer

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBuyer)

            LoadAllActive = From MediaBuyer In DbContext.GetQuery(Of Database.Entities.MediaBuyer)
                            Where MediaBuyer.IsInactive = False AndAlso
                                  MediaBuyer.Employee IsNot Nothing AndAlso
                                  MediaBuyer.Employee.TerminationDate Is Nothing
                            Select MediaBuyer

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBuyer)

            Load = From MediaBuyer In DbContext.GetQuery(Of Database.Entities.MediaBuyer)
                   Select MediaBuyer

        End Function

#End Region

    End Module

End Namespace
