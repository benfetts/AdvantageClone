Namespace Database.Procedures.VendorContractContact

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VendorContractContact)

            Load = DbContext.GetQuery(Of Database.Entities.VendorContractContact)

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.VendorContractContact

            Try

                LoadByID = (From VendorContractContact In DbContext.GetQuery(Of Database.Entities.VendorContractContact)
                            Where VendorContractContact.ID = ID
                            Select VendorContractContact).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByContractID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.VendorContractContact)

            Try

                LoadByContractID = From VendorContractContact In DbContext.GetQuery(Of Database.Entities.VendorContractContact)
                                   Where VendorContractContact.ContractID = ContractID
                                   Select VendorContractContact

            Catch ex As Exception
                LoadByContractID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContractContact As AdvantageFramework.Database.Entities.VendorContractContact, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.VendorContractContacts.Add(VendorContractContact)

                ErrorMessage = VendorContractContact.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContractContact As AdvantageFramework.Database.Entities.VendorContractContact, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(VendorContractContact).State = Entity.EntityState.Modified

                ErrorMessage = VendorContractContact.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContractContact As AdvantageFramework.Database.Entities.VendorContractContact) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(VendorContractContact).State = Entity.EntityState.Deleted

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
