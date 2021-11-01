Namespace Database.Procedures.Contract

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

        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Contract)

            LoadByClientCode = From Contract In DbContext.GetQuery(Of Database.Entities.Contract)
                               Where Contract.ClientCode = ClientCode AndAlso
                                     Contract.DivisionCode Is Nothing AndAlso
                                     Contract.ProductCode Is Nothing
                               Select Contract

        End Function
        Public Function LoadByClientAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Contract)

            LoadByClientAndDivisionCode = From Contract In DbContext.GetQuery(Of Database.Entities.Contract)
                                          Where Contract.ClientCode = ClientCode AndAlso
                                                Contract.DivisionCode = DivisionCode AndAlso
                                                Contract.ProductCode Is Nothing
                                          Select Contract

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Contract)

            LoadByClientAndDivisionAndProductCode = From Contract In DbContext.GetQuery(Of Database.Entities.Contract)
                                                    Where Contract.ClientCode = ClientCode AndAlso
                                                          Contract.DivisionCode = DivisionCode AndAlso
                                                          Contract.ProductCode = ProductCode
                                                    Select Contract

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.Contract

            Try

                LoadByID = (From Contract In DbContext.GetQuery(Of Database.Entities.Contract)
                            Where Contract.ID = ID
                            Select Contract).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Contract)

            Load = From Contract In DbContext.GetQuery(Of Database.Entities.Contract)
                   Select Contract

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Contracts.Add(Contract)

                ErrorText = Contract.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Contract)

                ErrorText = Contract.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ContractValueAddeds As IEnumerable(Of AdvantageFramework.Database.Entities.ContractValueAdded) = Nothing
            Dim ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing
            Dim ContractDocuments As IEnumerable(Of AdvantageFramework.Database.Entities.ContractDocument) = Nothing
            Dim ContractDocument As AdvantageFramework.Database.Entities.ContractDocument = Nothing
            Dim ContractReports As IEnumerable(Of AdvantageFramework.Database.Entities.ContractReport) = Nothing
            Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing

            Try

                If IsValid Then

                    If DbContext.Database.Connection.State <> ConnectionState.Open Then

                        DbContext.Database.Connection.Open()

                    End If

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CONTRACT_FEES WHERE CONTRACT_ID={0}", Contract.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CONTRACT_CONTACTS WHERE CONTRACT_ID={0}", Contract.ID))

                        ContractDocuments = AdvantageFramework.Database.Procedures.ContractDocument.LoadByContractID(DbContext, Contract.ID)
                        For Each ContractDocument In ContractDocuments

                            AdvantageFramework.Database.Procedures.ContractDocument.Delete(DbContext, ContractDocument)

                        Next

                        ContractValueAddeds = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByContractID(DbContext, Contract.ID)
                        For Each ContractValueAdded In ContractValueAddeds

                            AdvantageFramework.Database.Procedures.ContractValueAdded.Delete(DbContext, ContractValueAdded)

                        Next

                        ContractReports = AdvantageFramework.Database.Procedures.ContractReport.LoadByContractID(DbContext, Contract.ID)
                        For Each ContractReport In ContractReports

                            AdvantageFramework.Database.Procedures.ContractReport.Delete(DbContext, ContractReport)

                        Next

                        DbContext.DeleteEntityObject(Contract)

                        DbContext.SaveChanges()

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    Try

                        If Deleted Then

                            DbTransaction.Commit()

                        Else

                            DbTransaction.Rollback()

                        End If

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    DbContext.Database.Connection.Close()

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
