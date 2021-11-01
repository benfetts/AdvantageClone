Namespace Reporting.Database.Procedures.UserDefinedReport

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

		Public Function LoadByUserDefinedReportCategoryID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal UserDefinedReportCategoryID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.UserDefinedReport)

			LoadByUserDefinedReportCategoryID = From UserDefinedReport In ReportingDbContext.GetQuery(Of Database.Entities.UserDefinedReport)
												Where UserDefinedReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID
												Select UserDefinedReport

		End Function
		Public Function LoadByUserDefinedReportID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal UserDefinedReportID As Integer) As Reporting.Database.Entities.UserDefinedReport

			Try

				LoadByUserDefinedReportID = (From UserDefinedReport In ReportingDbContext.GetQuery(Of Database.Entities.UserDefinedReport)
											 Where UserDefinedReport.ID = UserDefinedReportID
											 Select UserDefinedReport).SingleOrDefault

			Catch ex As Exception
				LoadByUserDefinedReportID = Nothing
			End Try

		End Function
		Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.UserDefinedReport)

			Load = From UserDefinedReport In ReportingDbContext.GetQuery(Of Database.Entities.UserDefinedReport)
				   Select UserDefinedReport

		End Function
		Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext,
							   ByVal AdvancedReportWriterType As AdvantageFramework.Reporting.AdvancedReportWriterReports,
							   ByVal Description As String, ByVal CreatedByUserCode As String,
							   ByVal CreatedDate As Date, ByVal ReportDefinition As String,
							   ByVal UserDefinedReportCategoryID As Nullable(Of Integer),
							   ByRef UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport) As Boolean

			'objects
			Dim Inserted As Boolean = False

			Try

				UserDefinedReport = New AdvantageFramework.Reporting.Database.Entities.UserDefinedReport

				UserDefinedReport.DbContext = ReportingDbContext
				UserDefinedReport.AdvancedReportWriterType = AdvancedReportWriterType
				UserDefinedReport.Description = Description
				UserDefinedReport.CreatedByUserCode = CreatedByUserCode
				UserDefinedReport.CreatedDate = CreatedDate
				UserDefinedReport.UpdatedByUserCode = CreatedByUserCode
				UserDefinedReport.UpdatedDate = CreatedDate
				UserDefinedReport.ReportDefinition = ReportDefinition
				UserDefinedReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID

				Inserted = Insert(ReportingDbContext, UserDefinedReport)

			Catch ex As Exception
				Inserted = False
			Finally
				Insert = Inserted
			End Try

		End Function
		Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport) As Boolean

			'objects
			Dim Inserted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				ReportingDbContext.UserDefinedReports.Add(UserDefinedReport)

				ErrorText = UserDefinedReport.ValidateEntity(IsValid)

				If IsValid Then

					ReportingDbContext.SaveChanges()

					Inserted = True

					Try

						ReportingDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[SEC_USER_UDRACCESS]([SEC_USER_ID], [USER_DEF_REPORT_ID], [IS_BLOCKED]) " &
																					"SELECT [SEC_USER_ID], {0}, 1 FROM [dbo].[SEC_USER]", UserDefinedReport.ID))

					Catch ex As Exception

					End Try

					Try

						ReportingDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[SEC_GROUP_UDRACCESS]([SEC_GROUP_ID], [USER_DEF_REPORT_ID], [IS_BLOCKED]) " &
																					"SELECT [SEC_GROUP_ID], {0}, 1 FROM [dbo].[SEC_GROUP]", UserDefinedReport.ID))

					Catch ex As Exception

					End Try

					Try

						ReportingDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[SEC_USER_UDRACCESS] SET IS_BLOCKED = 0 " &
																					"WHERE USER_DEF_REPORT_ID = {0} AND " &
																					"SEC_USER_ID IN (SELECT SU.SEC_USER_ID FROM [dbo].[SEC_USER] SU WHERE UPPER(SU.USER_CODE) = UPPER('{1}'))", UserDefinedReport.ID, UserDefinedReport.CreatedByUserCode))

					Catch ex As Exception

					End Try

					Try

						ReportingDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[SEC_GROUP_UDRACCESS] SET IS_BLOCKED = 0 " &
																					"WHERE USER_DEF_REPORT_ID = {0} AND " &
																					"SEC_GROUP_ID IN (SELECT SGU.SEC_GROUP_ID FROM [dbo].[SEC_GROUP_USER] SGU INNER JOIN [dbo].[SEC_USER] SU ON SU.SEC_USER_ID = SGU.SEC_USER_ID WHERE UPPER(SU.USER_CODE) = UPPER('{1}'))", UserDefinedReport.ID, UserDefinedReport.CreatedByUserCode))

					Catch ex As Exception

					End Try

				Else

					AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

				End If

			Catch ex As Exception
				Inserted = False
			Finally
				Insert = Inserted
			End Try

		End Function
		Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport) As Boolean

			'objects
			Dim Updated As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				ReportingDbContext.UpdateObject(UserDefinedReport)

				ErrorText = UserDefinedReport.ValidateEntity(IsValid)

				If IsValid Then

					ReportingDbContext.SaveChanges()

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
		Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport) As Boolean

			'objects
			Dim Deleted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				If IsValid Then

					If AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.DeleteByUserDefinedReportID(ReportingDbContext, UserDefinedReport.ID) Then

						If AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.DeleteByUserDefinedReportID(ReportingDbContext, UserDefinedReport.ID) Then

							ReportingDbContext.DeleteEntityObject(UserDefinedReport)

							ReportingDbContext.SaveChanges()

							Deleted = True

						End If

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
