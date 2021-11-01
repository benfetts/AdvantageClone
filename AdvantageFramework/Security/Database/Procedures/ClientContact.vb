Namespace Security.Database.Procedures.ClientContact

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

        Public Function LoadAllAvailableByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientContact)

            LoadAllAvailableByClientCode = From ClientContact In DbContext.GetQuery(Of Database.Entities.ClientContact)
                                           Where ClientContact.ClientCode = ClientCode AndAlso
                                                 ClientContact.IsClientPortalUser = 1 AndAlso
                                                 (ClientContact.IsInactive Is Nothing OrElse
                                                  ClientContact.IsInactive = 0) AndAlso
                                                 ClientContact.ClientPortalUsers.Count = 0
                                           Select ClientContact

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientContact)

            LoadByClientCode = From ClientContact In DbContext.GetQuery(Of Database.Entities.ClientContact)
                               Where ClientContact.ClientCode = ClientCode
                               Select ClientContact

        End Function
        Public Function LoadByClientContactID(ByVal DbContext As Database.DbContext, ByVal ClientContactID As Integer) As Security.Database.Entities.ClientContact

            Try

                LoadByClientContactID = (From ClientContact In DbContext.GetQuery(Of Database.Entities.ClientContact)
                                         Where ClientContact.ContactID = ClientContactID
                                         Select ClientContact).SingleOrDefault

            Catch ex As Exception
                LoadByClientContactID = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientContact)

            LoadAllActive = From ClientContact In DbContext.GetQuery(Of Database.Entities.ClientContact)
                            Where ClientContact.IsInactive Is Nothing OrElse
                                  ClientContact.IsInactive = 0
                            Select ClientContact

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientContact)

            Load = From ClientContact In DbContext.GetQuery(Of Database.Entities.ClientContact)
                   Select ClientContact

        End Function

#End Region

    End Module

End Namespace
