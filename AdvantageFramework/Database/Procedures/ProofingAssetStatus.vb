Namespace Database.Procedures.ProofingAssetStatus

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

        Public Function LoadByAlertIDAndDocumentID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal AlertID As Integer,
                                                   ByVal DocumentID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingAssetStatus)

            LoadByAlertIDAndDocumentID = From ProofingAssetStatus In DbContext.GetQuery(Of Database.Entities.ProofingAssetStatus)
                                         Where ProofingAssetStatus.AlertID = AlertID And ProofingAssetStatus.DocumentID = DocumentID
                                         Select ProofingAssetStatus

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal DocumentID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingAssetStatus)

            LoadByDocumentID = From ProofingAssetStatus In DbContext.GetQuery(Of Database.Entities.ProofingAssetStatus)
                               Where ProofingAssetStatus.DocumentID = DocumentID
                               Select ProofingAssetStatus

        End Function
        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingAssetStatus)

            LoadByAlertID = From ProofingAssetStatus In DbContext.GetQuery(Of Database.Entities.ProofingAssetStatus)
                            Where ProofingAssetStatus.AlertID = AlertID
                            Select ProofingAssetStatus

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingAssetStatus)

            Load = From ProofingAssetStatus In DbContext.GetQuery(Of Database.Entities.ProofingAssetStatus)
                   Select ProofingAssetStatus

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingAssetStatus As AdvantageFramework.Database.Entities.ProofingAssetStatus) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ProofingAssetStatuses.Add(ProofingAssetStatus)

                'ErrorText = ProofingAssetStatus.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingAssetStatus As AdvantageFramework.Database.Entities.ProofingAssetStatus) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ProofingAssetStatus)

                'ErrorText = ProofingAssetStatus.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingAssetStatus As AdvantageFramework.Database.Entities.ProofingAssetStatus) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsValid Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DbContext.DeleteEntityObject(ProofingAssetStatus)
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
