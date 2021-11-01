Namespace Database.Procedures.SalesClass

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

        Public Function LoadBySalesClassCode(ByVal DbContext As Database.DbContext, ByVal SalesClassCode As String) As Database.Entities.SalesClass

            Try

                LoadBySalesClassCode = (From SalesClass In DbContext.GetQuery(Of Database.Entities.SalesClass)
                                        Where SalesClass.Code = SalesClassCode
                                        Select SalesClass).SingleOrDefault

            Catch ex As Exception
                LoadBySalesClassCode = Nothing
            End Try

        End Function
        Public Function LoadAllActiveBySalesClassTypeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClassTypeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SalesClass)

            LoadAllActiveBySalesClassTypeCode = From SalesClass In LoadAllActive(DbContext)
                                                Where SalesClass.SalesClassTypeCode = SalesClassTypeCode OrElse
                                                      SalesClass.SalesClassTypeCode Is Nothing
                                                Select SalesClass

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SalesClass)

            LoadAllActive = From SalesClass In DbContext.GetQuery(Of Database.Entities.SalesClass)
                            Where SalesClass.IsInactive Is Nothing OrElse
                                  SalesClass.IsInactive = 0
                            Select SalesClass

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.SalesClass)

            Load = From SalesClass In DbContext.GetQuery(Of Database.Entities.SalesClass)
                   Select SalesClass

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClass As AdvantageFramework.Database.Entities.SalesClass) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.SalesClasses.Add(SalesClass)

                ErrorText = SalesClass.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClass As AdvantageFramework.Database.Entities.SalesClass) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(SalesClass)

                ErrorText = SalesClass.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClass As AdvantageFramework.Database.Entities.SalesClass) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try
                    
                    If DbContext.Database.SqlQuery(Of String)(String.Format("SELECT INTERNET_HEADER.MEDIA_TYPE FROM INTERNET_HEADER WHERE (INTERNET_HEADER.MEDIA_TYPE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT MAG_HEADER.MEDIA_TYPE FROM MAG_HEADER WHERE (MAG_HEADER.MEDIA_TYPE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT MAGAZINE_HEADER.MEDIA_TYPE FROM MAGAZINE_HEADER WHERE (MAGAZINE_HEADER.MEDIA_TYPE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT NEWS_HEADER.MEDIA_TYPE FROM NEWS_HEADER WHERE (NEWS_HEADER.MEDIA_TYPE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT NEWSPAPER_HEADER.MEDIA_TYPE FROM NEWSPAPER_HEADER WHERE (NEWSPAPER_HEADER.MEDIA_TYPE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT OUTDOOR_HEADER.MEDIA_TYPE FROM OUTDOOR_HEADER WHERE (OUTDOOR_HEADER.MEDIA_TYPE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT PRINT_EST_DTL.MEDIA_TYPE FROM PRINT_EST_DTL WHERE (PRINT_EST_DTL.MEDIA_TYPE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT JOB_LOG.SC_CODE FROM JOB_LOG WHERE (JOB_LOG.SC_CODE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT BILLING_RATE.SC_CODE FROM BILLING_RATE WHERE (BILLING_RATE.SC_CODE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT OFF_SC_ACCTS.SC_CODE FROM OFF_SC_ACCTS WHERE (OFF_SC_ACCTS.SC_CODE = '{0}') " & _
                                                                                "UNION " & _
                                                                                "SELECT SC_FORMAT.SC_CODE FROM SC_FORMAT WHERE (SC_FORMAT.SC_CODE = '{0}')" & _
                                                                                "UNION " & _
                                                                                "SELECT CLIENT.AVALARA_SC_CODE FROM CLIENT WHERE (CLIENT.AVALARA_SC_CODE = '{0}')",
                                                                                SalesClass.Code)).Any Then

                        IsValid = False
                        ErrorText = "This code is in use and cannot be deleted."

                    End If

                Catch ex As Exception
                    ErrorText = "Failed deleting sales class."
                    IsValid = False
                End Try

                If IsValid Then

                    DbContext.DeleteEntityObject(SalesClass)

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
