Namespace Database.Procedures.EmployeeTime

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

        Public Function GetHolidayHours(ByVal DbContext As Database.DbContext, ByVal EmployeeDate As Date) As AdvantageFramework.Timesheet.Settings.HolidayHours

            Dim Hrs As AdvantageFramework.Timesheet.Settings.HolidayHours = Nothing
            Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SQL = " SELECT
		                    [Hours] = SUM(ENT.[HOURS]), 
		                    [IsAllDay] = CAST(ALL_DAY AS BIT) 
	                    FROM 
		                    EMP_NON_TASKS ENT WITH(NOLOCK) 
	                    WHERE 
		                    ENT.[TYPE] = 'H' AND	@EMP_DATE BETWEEN ENT.[START_DATE] AND ENT.END_DATE
	                    GROUP BY
		                    ENT.ALL_DAY; "

            SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@EMP_DATE", SqlDbType.SmallDateTime)
            SqlParameterEmployeeDate.Value = EmployeeDate

            Try

                Hrs = DbContext.Database.SqlQuery(Of AdvantageFramework.Timesheet.Settings.HolidayHours)(SQL, SqlParameterEmployeeDate).SingleOrDefault

            Catch ex As Exception
                Hrs = Nothing
            End Try

            Return Hrs

        End Function

        Public Function LoadByEmployeeCodeAndDate(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, ByVal EmployeeDate As Date) As Database.Entities.EmployeeTime

            Try

                LoadByEmployeeCodeAndDate = (From EmployeeTime In DbContext.GetQuery(Of Database.Entities.EmployeeTime)
                                             Where EmployeeTime.EmployeeCode = EmployeeCode AndAlso
                                                       EmployeeTime.Date = EmployeeDate
                                             Select EmployeeTime).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCodeAndDate = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeCodeAndDateRange(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, ByVal DateFrom As Date, ByVal DateTo As Date) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTime)

            Try

                LoadByEmployeeCodeAndDateRange = From EmployeeTime In DbContext.GetQuery(Of Database.Entities.EmployeeTime)
                                                 Where EmployeeTime.EmployeeCode = EmployeeCode AndAlso
                                                       (EmployeeTime.Date >= DateFrom AndAlso EmployeeTime.Date <= DateTo)
                                                 Select EmployeeTime

            Catch ex As Exception
                LoadByEmployeeCodeAndDateRange = Nothing
            End Try

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeID As Integer) As Database.Entities.EmployeeTime

            Try

                LoadByID = (From EmployeeTime In DbContext.GetQuery(Of Database.Entities.EmployeeTime)
                            Where EmployeeTime.ID = EmployeeTimeID
                            Select EmployeeTime).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTime)

            Load = From EmployeeTime In DbContext.GetQuery(Of Database.Entities.EmployeeTime)
                   Select EmployeeTime


        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTime As Database.Entities.EmployeeTime) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimes.Add(EmployeeTime)

                ErrorText = EmployeeTime.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
