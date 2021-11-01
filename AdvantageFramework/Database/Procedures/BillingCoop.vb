Namespace Database.Procedures.BillingCoop

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingCoop)

            LoadAllActive = From BillingCoop In DbContext.GetQuery(Of Database.Entities.BillingCoop)
                            Where (BillingCoop.IsInactive Is Nothing OrElse
                                   BillingCoop.IsInactive = 0)
                            Select BillingCoop

        End Function
        Public Function LoadByBillingCoopCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingCoopCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingCoop)

            LoadByBillingCoopCode = From BillingCoop In DbContext.GetQuery(Of Database.Entities.BillingCoop)
                                    Where BillingCoop.Code = BillingCoopCode
                                    Select BillingCoop

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingCoop)

            Load = From BillingCoop In DbContext.GetQuery(Of Database.Entities.BillingCoop)
                   Select BillingCoop

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingCoop As AdvantageFramework.Database.Entities.BillingCoop) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.BillingCoops.Add(BillingCoop)

                ErrorText = BillingCoop.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingCoop As AdvantageFramework.Database.Entities.BillingCoop) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BillingCoop)

                ErrorText = BillingCoop.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingCoop As AdvantageFramework.Database.Entities.BillingCoop) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim SQLString As String = ""
            Dim InUse As Boolean = False

            Try

                SQLString = String.Format("SELECT INTERNET_HEADER.BILL_COOP_CODE FROM dbo.INTERNET_HEADER WHERE INTERNET_HEADER.BILL_COOP_CODE = '{0}' UNION " & _
                                          "SELECT JOB_LOG.BILL_COOP_CODE FROM dbo.JOB_LOG WHERE JOB_LOG.BILL_COOP_CODE = '{0}' UNION " & _
                                          "SELECT MAG_HEADER.BILL_COOP_CODE FROM dbo.MAG_HEADER WHERE MAG_HEADER.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT MAGAZINE_HEADER.BILL_COOP_CODE FROM dbo.MAGAZINE_HEADER WHERE MAGAZINE_HEADER.BILL_COOP_CODE = '{0}' UNION " & _
                                          "SELECT NEWS_HEADER.BILL_COOP_CODE FROM dbo.NEWS_HEADER WHERE NEWS_HEADER.BILL_COOP_CODE = '{0}' UNION " & _
                                          "SELECT NEWSPAPER_HEADER.BILL_COOP_CODE FROM dbo.NEWSPAPER_HEADER WHERE NEWSPAPER_HEADER.BILL_COOP_CODE = '{0}' UNION " & _
                                          "SELECT OUTDOOR_HEADER.BILL_COOP_CODE FROM dbo.OUTDOOR_HEADER WHERE OUTDOOR_HEADER.BILL_COOP_CODE = '{0}' UNION " & _
                                          "SELECT PRINT_EST_DTL.BILL_COOP_CODE FROM dbo.PRINT_EST_DTL WHERE PRINT_EST_DTL.BILL_COOP_CODE = '{0}' UNION " & _
                                          "SELECT RADIO_HEADER.BILL_COOP_CODE FROM dbo.RADIO_HEADER WHERE RADIO_HEADER.BILL_COOP_CODE = '{0}' UNION " & _
                                          "SELECT TV_HEADER.BILL_COOP_CODE FROM dbo.TV_HEADER WHERE TV_HEADER.BILL_COOP_CODE = '{0}'", BillingCoop.Code)

                InUse = DbContext.Database.SqlQuery(Of String)(SQLString).Count > 0

                If InUse Then

                    If (From Entity In LoadByBillingCoopCode(DbContext, BillingCoop.Code) _
                       Select Entity).Count = 1 Then

                        IsValid = False

                        ErrorText = "This code is in use and cannot be deleted."

                    End If

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(BillingCoop)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingCoopCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim SQLString As String = ""

            Try

                SQLString = String.Format("SELECT INTERNET_HEADER.BILL_COOP_CODE FROM dbo.INTERNET_HEADER WHERE INTERNET_HEADER.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT JOB_LOG.BILL_COOP_CODE FROM dbo.JOB_LOG WHERE JOB_LOG.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT MAG_HEADER.BILL_COOP_CODE FROM dbo.MAG_HEADER WHERE MAG_HEADER.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT MAGAZINE_HEADER.BILL_COOP_CODE FROM dbo.MAGAZINE_HEADER WHERE MAGAZINE_HEADER.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT NEWS_HEADER.BILL_COOP_CODE FROM dbo.NEWS_HEADER WHERE NEWS_HEADER.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT NEWSPAPER_HEADER.BILL_COOP_CODE FROM dbo.NEWSPAPER_HEADER WHERE NEWSPAPER_HEADER.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT OUTDOOR_HEADER.BILL_COOP_CODE FROM dbo.OUTDOOR_HEADER WHERE OUTDOOR_HEADER.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT PRINT_EST_DTL.BILL_COOP_CODE FROM dbo.PRINT_EST_DTL WHERE PRINT_EST_DTL.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT RADIO_HDR.BILL_COOP_CODE FROM dbo.RADIO_HDR WHERE RADIO_HDR.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT RADIO_HEADER.BILL_COOP_CODE FROM dbo.RADIO_HEADER WHERE RADIO_HEADER.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT TV_HDR.BILL_COOP_CODE FROM dbo.TV_HDR WHERE TV_HDR.BILL_COOP_CODE = '{0}' UNION " &
                                          "SELECT TV_HEADER.BILL_COOP_CODE FROM dbo.TV_HEADER WHERE TV_HEADER.BILL_COOP_CODE = '{0}'", BillingCoopCode)

                If DbContext.Database.SqlQuery(Of String)(SQLString).Count > 0 Then

                    If BillingCoopCode <> "" Then

                        IsValid = False

                        ErrorText = "This code is in use and cannot be deleted."

                    End If

                End If

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.BILLING_COOP WHERE BILL_COOP_CODE = '{0}'", BillingCoopCode))

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
