Namespace Security.Database.Procedures.UserUserDefinedReportAccess

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

		Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserUserDefinedReportAccess)

			LoadByUserID = From UserUserDefinedReportAccess In DbContext.GetQuery(Of Database.Entities.UserUserDefinedReportAccess)
						   Where UserUserDefinedReportAccess.UserID = UserID
						   Select UserUserDefinedReportAccess

		End Function
		Public Function LoadByUserDefinedReportIDAndUserID(ByVal DbContext As Database.DbContext, ByVal UserDefinedReportID As Integer, ByVal UserID As Integer) As Security.Database.Entities.UserUserDefinedReportAccess

            Try

                LoadByUserDefinedReportIDAndUserID = (From UserUserDefinedReportAccess In DbContext.GetQuery(Of Database.Entities.UserUserDefinedReportAccess)
                                                      Where UserUserDefinedReportAccess.UserID = UserID AndAlso
                                                            UserUserDefinedReportAccess.UserDefinedReportID = UserDefinedReportID
                                                      Select UserUserDefinedReportAccess).SingleOrDefault

            Catch ex As Exception
                LoadByUserDefinedReportIDAndUserID = Nothing
            End Try

        End Function
        Public Function LoadByUserDefinedReportID(ByVal DbContext As Database.DbContext, ByVal UserDefinedReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserUserDefinedReportAccess)

            LoadByUserDefinedReportID = From UserUserDefinedReportAccess In DbContext.GetQuery(Of Database.Entities.UserUserDefinedReportAccess)
                                        Where UserUserDefinedReportAccess.UserDefinedReportID = UserDefinedReportID
                                        Select UserUserDefinedReportAccess

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserUserDefinedReportAccess)

            Load = From UserUserDefinedReportAccess In DbContext.GetQuery(Of Database.Entities.UserUserDefinedReportAccess)
                   Select UserUserDefinedReportAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer,
                               ByVal UserDefinedReportID As Integer, ByVal IsBlocked As Boolean, _
                               ByRef UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserUserDefinedReportAccess = New AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess

                UserUserDefinedReportAccess.DbContext = DbContext
                UserUserDefinedReportAccess.UserID = UserID
                UserUserDefinedReportAccess.UserDefinedReportID = UserDefinedReportID
                UserUserDefinedReportAccess.IsBlocked = IsBlocked

                Inserted = Insert(DbContext, UserUserDefinedReportAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserUserDefinedReportAccesses.Add(UserUserDefinedReportAccess)

                ErrorText = UserUserDefinedReportAccess.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserUserDefinedReportAccess)

                ErrorText = UserUserDefinedReportAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(UserUserDefinedReportAccess)

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
        Public Function DeleteByUserID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER_UDRACCESS WHERE SEC_USER_ID = " & UserID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserID = Deleted
            End Try

        End Function
        Public Function DeleteByUserDefinedReportID(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal UserDefinedReportID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER_UDRACCESS WHERE USER_DEF_REPORT_ID = " & UserDefinedReportID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserDefinedReportID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
