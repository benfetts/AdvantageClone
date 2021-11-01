Namespace Security.Database.Procedures.UserUserDefinedReportPermission

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

		Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.UserUserDefinedReportPermission)

			LoadByUserID = From UserUserDefinedReportPermission In DbContext.GetQuery(Of Database.Views.UserUserDefinedReportPermission)
						   Where UserUserDefinedReportPermission.UserID = UserID
						   Select UserUserDefinedReportPermission

		End Function
		Public Function LoadByUserDefinedReportIDAndUserID(ByVal DbContext As Database.DbContext, ByVal UserDefinedReportID As Integer, ByVal UserID As Integer) As Security.Database.Views.UserUserDefinedReportPermission

			Try

				LoadByUserDefinedReportIDAndUserID = (From UserUserDefinedReportPermission In DbContext.GetQuery(Of Database.Views.UserUserDefinedReportPermission)
													  Where UserUserDefinedReportPermission.UserID = UserID AndAlso
															UserUserDefinedReportPermission.UserDefinedReportID = UserDefinedReportID
													  Select UserUserDefinedReportPermission).SingleOrDefault

			Catch ex As Exception
				LoadByUserDefinedReportIDAndUserID = Nothing
			End Try

		End Function
		Public Function LoadByUserDefinedReportID(ByVal DbContext As Database.DbContext, ByVal UserDefinedReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.UserUserDefinedReportPermission)

			LoadByUserDefinedReportID = From UserUserDefinedReportPermission In DbContext.GetQuery(Of Database.Views.UserUserDefinedReportPermission)
										Where UserUserDefinedReportPermission.UserDefinedReportID = UserDefinedReportID
										Select UserUserDefinedReportPermission

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.UserUserDefinedReportPermission)

			Load = From UserUserDefinedReportPermission In DbContext.GetQuery(Of Database.Views.UserUserDefinedReportPermission)
				   Select UserUserDefinedReportPermission

		End Function

#End Region

	End Module

End Namespace
