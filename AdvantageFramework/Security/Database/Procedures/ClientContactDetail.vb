Namespace Security.Database.Procedures.ClientContactDetail

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

        Public Function LoadByClientContactID(ByVal DbContext As Database.DbContext, ByVal ClientContactID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientContactDetail)

            LoadByClientContactID = From ClientContactDetail In DbContext.GetQuery(Of Database.Entities.ClientContactDetail)
                                    Where ClientContactDetail.ContactID = ClientContactID
                                    Select ClientContactDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientContactDetail)

            Load = From ClientContactDetail In DbContext.GetQuery(Of Database.Entities.ClientContactDetail)
                   Select ClientContactDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientContactDetail As AdvantageFramework.Security.Database.Entities.ClientContactDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.SecurityClientContactDetails.Add(ClientContactDetail)

                ErrorText = ClientContactDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If AdvantageFramework.Security.Database.Procedures.ClientContactDetail.LoadByClientContactID(DbContext, ClientContactDetail.ContactID).Count = 0 Then

                        ClientContactDetail.SequenceNumber = 1

                    Else

                        ClientContactDetail.SequenceNumber = (From Entity In AdvantageFramework.Security.Database.Procedures.ClientContactDetail.LoadByClientContactID(DbContext, ClientContactDetail.ContactID)
                                                              Select Entity.SequenceNumber).Max + 1

                    End If

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientContactDetail As AdvantageFramework.Security.Database.Entities.ClientContactDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientContactDetail)

                ErrorText = ClientContactDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientContactDetail As AdvantageFramework.Security.Database.Entities.ClientContactDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ClientContactDetail)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
