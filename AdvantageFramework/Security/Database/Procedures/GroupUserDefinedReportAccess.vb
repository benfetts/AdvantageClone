Namespace Security.Database.Procedures.GroupUserDefinedReportAccess

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

        Public Function LoadByUserDefinedReportIDAndGroupID(ByVal DbContext As Database.DbContext, ByVal UserDefinedReportID As Integer, ByVal GroupID As Integer) As Security.Database.Entities.GroupUserDefinedReportAccess

            Try

                LoadByUserDefinedReportIDAndGroupID = (From GroupUserDefinedReportAccess In DbContext.GetQuery(Of Database.Entities.GroupUserDefinedReportAccess)
                                                       Where GroupUserDefinedReportAccess.GroupID = GroupID AndAlso
                                                             GroupUserDefinedReportAccess.UserDefinedReportID = UserDefinedReportID
                                                       Select GroupUserDefinedReportAccess).SingleOrDefault

            Catch ex As Exception
                LoadByUserDefinedReportIDAndGroupID = Nothing
            End Try

        End Function
        Public Function LoadByUserDefinedReportID(ByVal DbContext As Database.DbContext, ByVal UserDefinedReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupUserDefinedReportAccess)

            LoadByUserDefinedReportID = From GroupUserDefinedReportAccess In DbContext.GetQuery(Of Database.Entities.GroupUserDefinedReportAccess)
                                        Where GroupUserDefinedReportAccess.UserDefinedReportID = UserDefinedReportID
                                        Select GroupUserDefinedReportAccess

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupUserDefinedReportAccess)

            Load = From GroupUserDefinedReportAccess In DbContext.GetQuery(Of Database.Entities.GroupUserDefinedReportAccess)
                   Select GroupUserDefinedReportAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer,
                               ByVal UserDefinedReportID As Integer, ByVal IsBlocked As Boolean, _
                               ByRef GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                GroupUserDefinedReportAccess = New AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess

                GroupUserDefinedReportAccess.DbContext = DbContext
                GroupUserDefinedReportAccess.GroupID = GroupID
                GroupUserDefinedReportAccess.UserDefinedReportID = UserDefinedReportID
                GroupUserDefinedReportAccess.IsBlocked = IsBlocked

                Inserted = Insert(DbContext, GroupUserDefinedReportAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GroupUserDefinedReportAccesses.Add(GroupUserDefinedReportAccess)

                ErrorText = GroupUserDefinedReportAccess.ValidateEntity(IsValid)

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
        Public Function InsertDefaultAccessByGroupID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[SEC_GROUP_UDRACCESS]([SEC_GROUP_ID], [USER_DEF_REPORT_ID], [IS_BLOCKED]) " & _
                                                                "SELECT {0}, [USER_DEF_REPORT_ID], 1 FROM [dbo].[USER_DEF_REPORT]", GroupID))

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                InsertDefaultAccessByGroupID = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GroupUserDefinedReportAccess)

                ErrorText = GroupUserDefinedReportAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GroupUserDefinedReportAccess)

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
        Public Function DeleteByGroupID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_GROUP_UDRACCESS WHERE SEC_GROUP_ID = " & GroupID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGroupID = Deleted
            End Try

        End Function
        Public Function DeleteByUserDefinedReportID(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal UserDefinedReportID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_GROUP_UDRACCESS WHERE USER_DEF_REPORT_ID = " & UserDefinedReportID)

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
