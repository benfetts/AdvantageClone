Namespace Database.Procedures.GeneralLedgerMappingExportGLAccount

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount)

            Load = From GeneralLedgerMappingExportGLAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerMappingExportGLAccount)
                   Select GeneralLedgerMappingExportGLAccount

        End Function
        Public Function LoadByTargetAccountID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TargetAccountID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount)

            LoadByTargetAccountID = From GeneralLedgerMappingExportGLAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerMappingExportGLAccount)
                                    Where GeneralLedgerMappingExportGLAccount.TargetAccountID = TargetAccountID
                                    Select GeneralLedgerMappingExportGLAccount

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount

            LoadByID = (From GeneralLedgerMappingExportGLAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerMappingExportGLAccount)
                        Where GeneralLedgerMappingExportGLAccount.ID = ID
                        Select GeneralLedgerMappingExportGLAccount).SingleOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerMappingExportGLAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GeneralLedgerMappingExportGLAccounts.Add(GeneralLedgerMappingExportGLAccount)

                ErrorText = GeneralLedgerMappingExportGLAccount.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerMappingExportGLAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GeneralLedgerMappingExportGLAccount)

                ErrorText = GeneralLedgerMappingExportGLAccount.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerMappingExportGLAccount As AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GeneralLedgerMappingExportGLAccount)

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
