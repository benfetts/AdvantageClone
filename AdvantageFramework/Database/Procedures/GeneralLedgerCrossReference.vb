Namespace Database.Procedures.GeneralLedgerCrossReference

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

        Public Function LoadBySourceGLACodeAndRecordSourceID(ByVal DbContext As Database.DbContext, ByVal SourceGLACode As String, ByVal RecordSourceID As Integer) As Database.Entities.GeneralLedgerCrossReference

            Try

                LoadBySourceGLACodeAndRecordSourceID = (From GeneralLedgerCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerCrossReference)
                                                        Where GeneralLedgerCrossReference.SourceGLACode = SourceGLACode AndAlso
                                                              GeneralLedgerCrossReference.RecordSourceID = RecordSourceID
                                                        Select GeneralLedgerCrossReference).SingleOrDefault

            Catch ex As Exception
                LoadBySourceGLACodeAndRecordSourceID = Nothing
            End Try

        End Function
        Public Function LoadByRecordSourceID(ByVal DbContext As Database.DbContext, ByVal RecordSourceID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerCrossReference)

            LoadByRecordSourceID = From GeneralLedgerCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerCrossReference)
                                   Where GeneralLedgerCrossReference.RecordSourceID = RecordSourceID
                                   Select GeneralLedgerCrossReference

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerCrossReference)

            Load = From GeneralLedgerCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerCrossReference)
                   Select GeneralLedgerCrossReference

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GeneralLedgerCrossReferences.Add(GeneralLedgerCrossReference)

                ErrorText = GeneralLedgerCrossReference.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GeneralLedgerCrossReference)

                ErrorText = GeneralLedgerCrossReference.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GeneralLedgerCrossReference)

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
