Namespace Database.Procedures.OtherCashReceipt

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OtherCashReceipt)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OtherCashReceipt)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.OtherCashReceipts, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal OtherCashReceipts As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.OtherCashReceipt), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OtherCashReceipt)

            LoadWithOfficeLimits = From OtherCashReceipt In OtherCashReceipts.Include("Bank")
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(OtherCashReceipt.OfficeCode)
                                   Select OtherCashReceipt

        End Function
        Public Function LoadByIDandSequenceNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer, ByVal SequenceNumber As Short) As Database.Entities.OtherCashReceipt

            Try

                LoadByIDandSequenceNumber = (From OtherCashReceipt In DbContext.GetQuery(Of Database.Entities.OtherCashReceipt)
                                             Where OtherCashReceipt.ID = ID AndAlso
                                                   OtherCashReceipt.SequenceNumber = SequenceNumber
                                             Select OtherCashReceipt).SingleOrDefault

            Catch ex As Exception
                LoadByIDandSequenceNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OtherCashReceipt)

            Load = From OtherCashReceipt In DbContext.GetQuery(Of Database.Entities.OtherCashReceipt)
                   Select OtherCashReceipt

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OtherCashReceipts.Add(OtherCashReceipt)

                ErrorText = OtherCashReceipt.ValidateEntity(IsValid)

                If IsValid Then

                    If OtherCashReceipt.ID = 0 Then

                        Try

                            OtherCashReceipt.ID = (From Entity In AdvantageFramework.Database.Procedures.OtherCashReceipt.Load(DbContext)
                                                   Select Entity.ID).Max + 1

                        Catch ex As Exception
                            OtherCashReceipt.ID = 1
                        End Try

                        OtherCashReceipt.SequenceNumber = 0

                    Else

                        Try

                            OtherCashReceipt.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.OtherCashReceipt.Load(DbContext)
                                                               Where Entity.ID = OtherCashReceipt.ID
                                                               Select Entity.SequenceNumber).Max + 1

                        Catch ex As Exception
                            IsValid = False
                        End Try

                    End If

                End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OtherCashReceipt)

                ErrorText = OtherCashReceipt.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
