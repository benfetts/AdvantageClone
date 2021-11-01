Namespace Database.Procedures.GeneralLedgerOfficeCrossReference

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleGLOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, GLOfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.GeneralLedgerOfficeCrossReferences, GLOfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal GeneralLedgerOfficeCrossReferences As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference), GLOfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)

            LoadWithOfficeLimits = From GeneralLedgerOfficeCrossReference In GeneralLedgerOfficeCrossReferences
                                   Where HasLimitedOfficeCodes = False OrElse
                                         GLOfficeCodes.Contains(GeneralLedgerOfficeCrossReference.Code)
                                   Select GeneralLedgerOfficeCrossReference

        End Function
        Public Function LoadWithOfficeLimitsOrderByOffice(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)

            LoadWithOfficeLimitsOrderByOffice = LoadWithOfficeLimits(LoadOrderByOffice(DbContext), Session.AccessibleGLOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimitsOrderByOffice(ByVal DbContext As AdvantageFramework.Database.DbContext, GLOfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)

            LoadWithOfficeLimitsOrderByOffice = LoadWithOfficeLimits(LoadOrderByOffice(DbContext), GLOfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)

            Load = From GeneralLedgerOfficeCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)
                   Select GeneralLedgerOfficeCrossReference

        End Function
        Public Function LoadOrderByOffice(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)

            LoadOrderByOffice = From GeneralLedgerOfficeCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)
                                Order By GeneralLedgerOfficeCrossReference.OfficeCode
                                Select GeneralLedgerOfficeCrossReference

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeCode As String) As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference

            Try

                LoadByOfficeCode = (From GeneralLedgerOfficeCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)
                                    Where GeneralLedgerOfficeCrossReference.OfficeCode = OfficeCode
                                    Select GeneralLedgerOfficeCrossReference).SingleOrDefault

            Catch ex As Exception
                LoadByOfficeCode = Nothing
            End Try

        End Function
        Public Function LoadByCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Code As String) As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference

            Try

                LoadByCode = (From GeneralLedgerOfficeCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)
                              Where GeneralLedgerOfficeCrossReference.Code = Code
                              Select GeneralLedgerOfficeCrossReference).SingleOrDefault

            Catch ex As Exception
                LoadByCode = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GeneralLedgerOfficeCrossReferences.Add(GeneralLedgerOfficeCrossReference)

                ErrorText = GeneralLedgerOfficeCrossReference.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GeneralLedgerOfficeCrossReference)

                ErrorText = GeneralLedgerOfficeCrossReference.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GeneralLedgerOfficeCrossReference)

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
        Public Function GetOfficeCodeByGLACode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLACode As String) As String

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim OfficeCode As String = Nothing

            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode)

            If GeneralLedgerAccount IsNot Nothing Then

                GeneralLedgerOfficeCrossReference = (From GLOCR In DbContext.GetQuery(Of Database.Entities.GeneralLedgerOfficeCrossReference)
                                                     Where GLOCR.Code = GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode
                                                     Select GLOCR).SingleOrDefault

                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                    OfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode

                End If

            End If

            GetOfficeCodeByGLACode = OfficeCode

        End Function

#End Region

    End Module

End Namespace
