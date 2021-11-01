Namespace Database.Procedures.VendorRepresentative

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.VendorRepresentative)

            Load = From VendorRepresentative In DataContext.VendorRepresentatives
                   Select VendorRepresentative

        End Function
        Public Function LoadActiveByCodeAndVendorCode(DataContext As Database.DataContext, VendorRepresentativeCode As String, VendorCode As String) As Database.Entities.VendorRepresentative

            If (From VendorRepresentative In DataContext.VendorRepresentatives
                Where VendorRepresentative.VendorCode = VendorCode AndAlso
                      VendorRepresentative.Code = VendorRepresentativeCode
                Select VendorRepresentative).Any Then

                LoadActiveByCodeAndVendorCode = (From VendorRepresentative In DataContext.VendorRepresentatives
                                                 Where VendorRepresentative.VendorCode = VendorCode AndAlso
                                                       VendorRepresentative.Code = VendorRepresentativeCode
                                                 Select VendorRepresentative).SingleOrDefault

            Else

                LoadActiveByCodeAndVendorCode = Nothing

            End If

        End Function
        Public Function LoadByCodeAndVendorCode(ByVal DataContext As Database.DataContext, ByVal VendorRepresentativeCode As String, ByVal VendorCode As String) As Database.Entities.VendorRepresentative

            Try

                LoadByCodeAndVendorCode = (From VendorRepresentative In DataContext.VendorRepresentatives
                                           Where VendorRepresentative.VendorCode = VendorCode AndAlso
                                                 VendorRepresentative.Code = VendorRepresentativeCode
                                           Select VendorRepresentative).SingleOrDefault

            Catch ex As Exception
                LoadByCodeAndVendorCode = Nothing
            End Try

        End Function
        Public Function LoadActiveByVendorCode(DataContext As Database.DataContext, VendorCode As String) As IQueryable(Of Database.Entities.VendorRepresentative)

            LoadActiveByVendorCode = From VendorRepresentative In DataContext.VendorRepresentatives
                                     Where VendorRepresentative.VendorCode = VendorCode AndAlso
                                           (VendorRepresentative.IsInactive Is Nothing OrElse
                                           VendorRepresentative.IsInactive = 0)
                                     Select VendorRepresentative

        End Function
        Public Function LoadByVendorCode(ByVal DataContext As Database.DataContext, ByVal VendorCode As String) As IQueryable(Of Database.Entities.VendorRepresentative)

            LoadByVendorCode = From VendorRepresentative In DataContext.VendorRepresentatives
                               Where VendorRepresentative.VendorCode = VendorCode
                               Select VendorRepresentative

        End Function
        Public Function LoadWithOfficeLimits(DbContext As AdvantageFramework.Database.DbContext, DataContext As Database.DataContext, Session As AdvantageFramework.Security.Session) As IQueryable(Of Database.Entities.VendorRepresentative)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, DataContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(DbContext As AdvantageFramework.Database.DbContext, DataContext As Database.DataContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As IQueryable(Of Database.Entities.VendorRepresentative)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DataContext.VendorRepresentatives, DbContext, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(VendorRepresentatives As IQueryable(Of AdvantageFramework.Database.Entities.VendorRepresentative), DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As IQueryable(Of Database.Entities.VendorRepresentative)

            Dim VendorCodes As System.Collections.Generic.List(Of String) = Nothing

            VendorCodes = AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, OfficeCodes, HasLimitedOfficeCodes).Select(Function(Entity) Entity.Code).ToList

            LoadWithOfficeLimits = From VendorRepresentative In VendorRepresentatives
                                   Where HasLimitedOfficeCodes = False OrElse
                                         VendorCodes.Contains(VendorRepresentative.VendorCode)
                                   Select VendorRepresentative

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                VendorRepresentative.DataContext = DataContext

                VendorRepresentative.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.VendorRepresentatives.InsertOnSubmit(VendorRepresentative)

                ErrorText = VendorRepresentative.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                VendorRepresentative.DataContext = DataContext

                VendorRepresentative.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = VendorRepresentative.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DataContext.ExecuteCommand(String.Format("DELETE FROM dbo.VEN_REP WHERE VN_CODE = '{0}' AND VR_CODE = '{1}'", VendorRepresentative.VendorCode, VendorRepresentative.Code))

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    If IsValid Then

                        DataContext.ExecuteCommand(String.Format("DELETE FROM dbo.VEN_REP_CLIENTS WHERE VN_CODE = '{0}' AND VR_CODE = '{1}'", VendorRepresentative.VendorCode, VendorRepresentative.Code))

                        Deleted = True

                    End If

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