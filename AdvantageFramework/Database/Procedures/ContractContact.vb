Namespace Database.Procedures.ContractContact

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractContact)

            Load = From ContractContact In DbContext.GetQuery(Of Database.Entities.ContractContact)
                   Select ContractContact

        End Function
        Public Function LoadByContractID(ByVal DbContext As Database.DbContext, ByVal ContractID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractContact)

            LoadByContractID = From ContractContact In DbContext.GetQuery(Of Database.Entities.ContractContact)
                               Where ContractContact.ContractID = ContractID
                               Select ContractContact

        End Function
        Public Function LoadByContractIDAndEmployeeCode(ByVal DbContext As Database.DbContext, ByVal ContractID As Integer, ByVal EmployeeCode As String) As Database.Entities.ContractContact

            Try

                LoadByContractIDAndEmployeeCode = (From ContractContact In DbContext.GetQuery(Of Database.Entities.ContractContact)
                                                   Where ContractContact.ContractID = ContractID AndAlso
                                                         ContractContact.EmployeeCode = EmployeeCode
                                                   Select ContractContact).SingleOrDefault

            Catch ex As Exception
                LoadByContractIDAndEmployeeCode = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractContact As AdvantageFramework.Database.Entities.ContractContact) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ContractContacts.Add(ContractContact)

                ErrorText = ContractContact.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractContact As AdvantageFramework.Database.Entities.ContractContact) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ContractContact)

                ErrorText = ContractContact.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractContact As AdvantageFramework.Database.Entities.ContractContact) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ContractContact)

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
